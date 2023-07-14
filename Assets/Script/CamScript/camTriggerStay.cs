using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camTriggerStay : MonoBehaviour
{
    public GameObject activeCam;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            activeCam.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        activeCam.SetActive(false);
    }
}
