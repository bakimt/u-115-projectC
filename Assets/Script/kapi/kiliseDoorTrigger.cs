using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiliseDoorTrigger : MonoBehaviour
{
    private Animator kapiAnim;

    void Start()
    {
        kapiAnim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        kapiAnim.SetBool("kiliseclose", false);
        if (other.CompareTag("Player")) kapiAnim.SetBool("kiliseopen", true);
    }
    void OnTriggerExit(Collider other)
    {
        kapiAnim.SetBool("kiliseopen", false);
        if (other.CompareTag("Player")) kapiAnim.SetBool("kiliseclose", true);
    }
}
