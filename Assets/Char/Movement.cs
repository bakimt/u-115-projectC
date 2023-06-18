using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _walkSpeed = 0.5f;
    [SerializeField] private float _runSpeed = 1f;
    [SerializeField] private float _glideSpeed = 2f;
    [SerializeField] private float _turnSpeed = 360;
    private Vector3 _input;
    private bool _isGrounded;
    private bool _isRunning;
    private bool _isGliding;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        GatherInput();
        Look();

        if (_isGrounded)
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
        }
        else
        {
            _animator.SetFloat("Speed", 0f);
        }

        _animator.SetBool("isGliding", _isGliding);
    }

    private void OnTriggerEnter(Collider other)
    {
        _isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isGrounded = false;
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        _isRunning = Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W);
        _isGliding = Input.GetKey(KeyCode.Space) && !_isGrounded && !_isRunning && _input.magnitude > 0;
    }

    private void Look()
    {
        if (_input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
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
