using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerColliderDeneme : MonoBehaviour
{
    public GameObject doorMesh;

    void Start()
    {
        doorMesh.GetComponent<Animator>().SetBool("closeDoor", false);
        doorMesh.GetComponent<Animator>().SetBool("openDoor", false);
    }

    void OnTriggerEnter(Collider other)
    {
        doorMesh.GetComponent<Animator>().SetBool("closeDoor", false);
        if (other.CompareTag("Player")) doorMesh.GetComponent<Animator>().SetBool("openDoor", true);
    }
    void OnTriggerExit(Collider other)
    {
        doorMesh.GetComponent<Animator>().SetBool("openDoor", false);
        if (other.CompareTag("Player")) doorMesh.GetComponent<Animator>().SetBool("closeDoor", true);
    }
}
