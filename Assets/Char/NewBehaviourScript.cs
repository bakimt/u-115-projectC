using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoaringController : MonoBehaviour
{
    public float jumpForce = 5f; // The force applied when the character jumps
    public KeyCode jumpKey = KeyCode.Space; // The key to trigger the jump

    private Rigidbody rb; // Reference to the character's Rigidbody component
    private bool isJumping = false; // Flag to check if the character is currently jumping

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    private void Update()
    {
        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Apply upward force when the jump key is pressed
            isJumping = true;
        }
    }
}
