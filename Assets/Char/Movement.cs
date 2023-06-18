using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    private Animator animator;
    private Vector3 _input;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        GatherInput(); // Kullanıcı girişini toplar.
        Look(); // Oyuncunun hareket yönüne bakmasını sağlar.

        // Hareket etme animasyonunu ayarlar.
        if (_input.magnitude > 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void FixedUpdate() {
        Move(); // Karakteri hareket ettirir.
    }

    private void GatherInput() {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")); // Kullanıcıdan yatay ve dikey girişi toplar.
    }

    private void Look() {
        if (_input == Vector3.zero) return; // Eğer giriş yoksa dönüş yapma.

        // Karakterin giriş yönüne bakmasını sağlar.
        var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
    }

    private void Move() {
        // Karakteri hareket ettirir.
        _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);
    }
}

public static class Helpers 
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 0, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}