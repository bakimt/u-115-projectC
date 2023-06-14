using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    bool isGround;
    bool pressedShift;
    
    private Vector3 _input;

    private void Update() {
        GatherInput();
        Look();
        if(Input.GetButtonDown("Jump") && isGround == true && pressedShift == false)
        {
            _rb.AddForce(new Vector3(0,5,0), ForceMode.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && isGround == false)
        {
              Physics.gravity = new Vector3(0, -3.0F, 0);
              pressedShift = true;

        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
              Physics.gravity = new Vector3(0, -9.8F, 0);
              pressedShift = false;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        isGround = true;
        //print ("karada");
    }
    private void OnTriggerExit(Collider other)
    {
        isGround = false;
        //print("havada");
    }

    private void FixedUpdate() {
        Move();
    }

    private void GatherInput() {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Look() {
        if (_input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
    }

    private void Move() {
        _rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);
    }
}

public static class Helpers 
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 0, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}
