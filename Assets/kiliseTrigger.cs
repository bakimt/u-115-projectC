using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiliseTrigger : MonoBehaviour
{
    public GameObject doorMesh;

    void Start()
    {
        doorMesh.GetComponent<Animator>().SetBool("kiliseclose", false);
        doorMesh.GetComponent<Animator>().SetBool("kiliseopen", false);
    }

    void OnTriggerEnter(Collider other)
    {
        doorMesh.GetComponent<Animator>().SetBool("kiliseclose", false);
        if (other.CompareTag("Player")) doorMesh.GetComponent<Animator>().SetBool("kiliseopen", true);
        Debug.Log("kapý açýldý");
    }
    void OnTriggerExit(Collider other)
    {
        doorMesh.GetComponent<Animator>().SetBool("kiliseopen", false);
        if (other.CompareTag("Player")) doorMesh.GetComponent<Animator>().SetBool("kiliseclose", true);
    }
}