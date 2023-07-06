using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcindenGecme : MonoBehaviour
{
    public Collider objectCollider;
    private bool canGoThrough = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canGoThrough)
        {
            objectCollider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canGoThrough = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectCollider.enabled = true;
            canGoThrough = false;
        }
    }
}
