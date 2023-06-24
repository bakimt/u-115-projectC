using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour
{
    private Animator kapiAnim;

    void Start ()
    {
        kapiAnim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        kapiAnim.SetBool("closeDoor", false);
        if (other.CompareTag("Player")) kapiAnim.SetBool("openDoor", true);
    }
    void OnTriggerExit(Collider other)
    {
        kapiAnim.SetBool("openDoor", false);
        if (other.CompareTag("Player")) kapiAnim.SetBool("closeDoor", true);
    }
}
