using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRelative : MonoBehaviour
{
    Transform cam;
    Rigidbody charRB;
    [SerializeField] float MoveSpeed = 15f;
    [SerializeField] float JumpForce = 5f;
    [SerializeField] float RunSpeed = 15f;
    public Animator charAnimator;
    bool isGrounded;
    bool isGliding;
    bool isJumping;
    bool isMoving = false;
    bool isRunning = false;

    void Start()
    {
        charRB = GetComponent<Rigidbody>();
        charAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        cam = Camera.main.transform;
        Move();
        Jump();
        if (isMoving == true)
        {
            charAnimator.SetBool("isMoving", true);
        }
        else
        {
            charAnimator.SetBool("isMoving", false);
        }
    }

    void Move()
    {
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;

        Vector3 moveDir = (verInput * camForward + horInput * camRight).normalized;
        Vector3 velocity = moveDir * MoveSpeed;
        velocity.y = charRB.velocity.y;

        charRB.velocity = velocity;

        if (moveDir != Vector3.zero) 
        {
            transform.forward = moveDir;
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            charRB.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isGrounded = false;
            isJumping = true;
            charAnimator.SetBool("isJumping", true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
            charAnimator.SetBool("isJumping", false);
        }
    }

    void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded == true)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }
}
