using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour
{
    [SerializeField] private Animator door = null;
    [SerializeField] private bool openDoor = false;
    [SerializeField] private bool closeDoor = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("Player"))
        {
            if (openDoor)
            {
                door.Play("acilKapi", 0, 0.0f);
                gameObject.SetActive(false);
            }

            else if (closeDoor)
            {
                door.Play("kapanKapi", 0, 0.0f);
                gameObject.SetActive(false);
            }
    }
    }
}
