using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRelative : MonoBehaviour
{
    Transform cam;
    Rigidbody charRB;
    [SerializeField] float MoveSpeed = 6f;
    [SerializeField] float JumpForce = 5f;
    float RunSpeed = 10f;
    public Animator charAnimator;
    bool isGrounded;
    bool isGliding;
    bool isJumping;
    public bool isMoving = false;
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
        Run();
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
        if (Input.GetButtonDown("Jump") && isGrounded == true && isRunning == true)
        {
            charRB.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isGrounded = false;
            isJumping = true;
            charAnimator.SetBool("isJumping", true);
        }

        if (Input.GetMouseButtonDown(1) && isJumping == true)
        {
            Physics.gravity = new Vector3(0, -3.0F, 0);
            charAnimator.SetBool("isGliding", true);
            isGliding = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            Physics.gravity = new Vector3(0, -9.81F, 0);
            charAnimator.SetBool("isGliding", false);
            charAnimator.SetBool("isGrounded", true);
            isGliding = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Physics.gravity = new Vector3(0, -9.81F, 0);
            isGrounded = true;
            isJumping = false;
            charAnimator.SetBool("isJumping", false);
            charAnimator.SetBool("isGliding", false);
            charAnimator.SetBool("isGrounded", true);
        }
    }

    void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            MoveSpeed = RunSpeed;
            isRunning = true;
            charAnimator.SetBool("isMoving", false);
            charAnimator.SetBool("isRunning", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            MoveSpeed = 6f;
            isRunning = false;
            charAnimator.SetBool("isMoving", true);
            charAnimator.SetBool("isRunning", false);
        }
    }
}
