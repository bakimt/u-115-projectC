using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sagSolX : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveRange = 5f;

    private float initialX;

    private void Start()
    {
        initialX = transform.position.x;
    }

    private void Update()
    {
        float movement = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        Vector3 newPosition = new Vector3(initialX + movement, transform.position.y, transform.position.z);

        transform.position = newPosition;
    }
}

