using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sagSolX : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hızı
    public float moveRange = 5f; // Hareket aralığı

    private float initialX; // İlk konumun x koordinatı

    private void Start()
    {
        initialX = transform.position.x; // İlk konumu kaydet
    }

    private void Update()
    {
        // Hareket hesaplaması
        float movement = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        Vector3 newPosition = new Vector3(initialX + movement, transform.position.y, transform.position.z);

        // Yeni pozisyonu atama
        transform.position = newPosition;
    }
}

