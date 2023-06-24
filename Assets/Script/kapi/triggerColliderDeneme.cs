using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerColliderDeneme : MonoBehaviour
{
    [SerializeField] Animator kapiMesh;

    void Start ()
    {
        kapiMesh = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {

        kapiMesh.SetBool("closeDoor", false);
        if (other.CompareTag("Player")) kapiMesh.SetBool("openDoor", true);
    }
}
