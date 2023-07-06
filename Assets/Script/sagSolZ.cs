using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sagSolZ : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hızı
    public float moveRange = 5f; // Hareket aralığı

    private float initialZ; // İlk konumun z koordinatı

    private void Start()
    {
        initialZ = transform.position.z; // İlk konumu kaydet
    }

    private void Update()
    {
        // Hareket hesaplaması
        float movement = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, initialZ + movement);

        // Yeni pozisyonu atama
        transform.position = newPosition;
    }
}

