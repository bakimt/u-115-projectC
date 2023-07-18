using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sagSolZ : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveRange = 5f;

    private float initialZ;

    private void Start()
    {
        initialZ = transform.position.z;
    }

    private void Update()
    {
        float movement = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, initialZ + movement);

        transform.position = newPosition;
    }
}

