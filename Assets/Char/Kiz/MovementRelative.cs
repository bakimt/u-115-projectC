using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRelative : MonoBehaviour
{
    Transform cam;
    Rigidbody charRB;
    [SerializeField] float MoveSpeed = 15;
    public Animator charAnimator;
    bool isGrounded;
    bool isGliding;
    bool isJumping;
    bool isMoving = false;

    void Start()
    {
        charRB = GetComponent<Rigidbody>();
        charAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cam = Camera.main.transform;
        Move();
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
}
