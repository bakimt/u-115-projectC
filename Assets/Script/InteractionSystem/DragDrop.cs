using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public Transform charKiz;
    public GameObject charKizObject;
    private Animator charKizAnim;
    public float maxDistance = 3f;
    private bool isDragging = false;
    private Rigidbody rb;
    public float smoothSpeed = 5f;
    public float minYPosition = -10f;
    public float maxYPosition = 10f;

    private void Start()
    {
        charKizAnim = charKizObject.GetComponent<Animator>();
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
            targetPosition.y = Mathf.Clamp(targetPosition.y, minYPosition, maxYPosition);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
            Vector3 direction = transform.position - charKiz.position;
            direction.y = 0f;
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                charKiz.rotation = targetRotation;
            }

            if (Vector3.Distance(transform.position, charKiz.position) > maxDistance)
            {
                charKizAnim.SetBool("isMoving", false);
                charKizAnim.SetBool("isDrag", false);
                isDragging = false;
                rb.useGravity = true;
            }
            else
            {
                charKizAnim.SetBool("isMoving", false);
                charKizAnim.SetBool("isDrag", true);
            }
        }
    }

    private void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;
            rb.useGravity = true;
            charKizAnim.SetBool("isMoving", false);
            charKizAnim.SetBool("isDrag", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDragging)
        {
            isDragging = false;
            rb.useGravity = true;
            charKizAnim.SetBool("isMoving", false);
            charKizAnim.SetBool("isDrag", false);
        }
    }
}
