using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public Transform charKiz;
    private bool isDragging = false;
    private Rigidbody rb;

    // Eklenen değişkenler
    public float smoothSpeed = 5f; // Yumuşaklık hızı

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        isDragging = true;
        rb.useGravity = false;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 targetPosition = GetMouseWorldPos() + mOffset;
            targetPosition.z = transform.position.z;

            // Hareketin yumuşaklaştırılması
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

            Vector3 direction = transform.position - charKiz.position;
            direction.y = 0f;

            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                charKiz.rotation = targetRotation;
            }
        }
    }

    private void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;
            rb.useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDragging)
        {
            isDragging = false;
            rb.useGravity = true;
        }
    }
}
