using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sagSol : MonoBehaviour
{
    public float speed = 5f; 
    public float distance = 5f; 

    private Vector3 initialPosition; 
    private bool isMovingRight = true; 

    private void Start()
    {
        initialPosition = transform.position; 
    }

    private void Update()
    {
 
        if (isMovingRight)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        else
            transform.Translate(Vector3.left * speed * Time.deltaTime);


        if (Mathf.Abs(transform.position.x - initialPosition.x) >= distance)
            ChangeDirection();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            ChangeDirection();
    }

    private void ChangeDirection()
    {
        isMovingRight = !isMovingRight; 
    }
}

