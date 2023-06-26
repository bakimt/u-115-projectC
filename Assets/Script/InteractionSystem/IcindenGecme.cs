using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcindenGecme : MonoBehaviour
{
    // Reference to the object's collider component
    public Collider objectCollider;

    // Determine if the player is currently able to go through the object
    private bool canGoThrough = false;

    private void Update()
    {
        // Check if the player presses the "E" key
        if (Input.GetKeyDown(KeyCode.E) && canGoThrough)
        {
            // Disable the object's collider to allow the player to go through
            objectCollider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {
            // Set canGoThrough to true when the player enters the trigger zone
            canGoThrough = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the trigger zone
        if (other.CompareTag("Player"))
        {
            objectCollider.enabled = true;
            // Set canGoThrough to false when the player exits the trigger zone
            canGoThrough = false;
        }
    }
}
