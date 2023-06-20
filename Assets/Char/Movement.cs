using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _walkSpeed = 0.5f;
    [SerializeField] private float _runSpeed = 3f;
    [SerializeField] private float _glideSpeed = 4f;
    [SerializeField] private float _turnSpeed = 360;
    private Vector3 _input;
    private bool _isRunning;
    private bool _isGliding;
    private bool _isJumping;
    private bool _isMoving;
    private bool _isGrounded; // isGrounded parametresi
    [SerializeField] private bool isInteracting;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            isInteracting = true;
        }
        else if (other.CompareTag("Ground"))
        {
            _isGrounded = true; // Collider'ın etkileşime geçtiği yerde _isGrounded parametresini true yap
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            isInteracting = false;
        }
        else if (other.CompareTag("Ground"))
        {
            _isGrounded = false; // Collider'ın etkileşimden çıktığı yerde _isGrounded parametresini false yap
        }
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        GatherInput();
        Look();

        if (_isGrounded) // _isGrounded parametresine göre hareket durumunu kontrol et
        {
            if (_isRunning)
            {
                _animator.SetFloat("Speed", _runSpeed);
            }
            else if (_input.magnitude > 0)
            {
                _animator.SetFloat("Speed", _walkSpeed);
            }
            else
            {
                _animator.SetFloat("Speed", 0f);
            }

            _animator.SetBool("isJumping", _isJumping);
        }
        else
        {
            _animator.SetFloat("Speed", 0f);
            _animator.SetBool("isJumping", false);
        }

        _animator.SetBool("isGliding", _isGliding);
        _animator.SetBool("isMoving", _isMoving);
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        _isRunning = (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)));
        _isGliding = Input.GetKey(KeyCode.Space) && !_isGrounded && !_isRunning && _input.magnitude > 0;
        _isJumping = Input.GetKeyDown(KeyCode.Space) && _isGrounded;
        _isMoving = _input.magnitude > 0;
    }

    private void Look()
    {
        if (_input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(_input, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
    }

    private void ApplyMovement()
    {
        Vector3 movement = transform.forward * _input.magnitude;
        if (_isGliding)
        {
            movement += Vector3.down * _glideSpeed;
        }
        else if (_isRunning)
        {
            movement *= _runSpeed;
        }
        else
        {
            movement *= _walkSpeed;
        }

        _rb.MovePosition(transform.position + movement * Time.deltaTime);
    }
}

public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 0, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}
