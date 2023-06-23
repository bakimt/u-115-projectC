using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignController : MonoBehaviour
{
    public GameObject signObject; 

    private bool isPlayerInRange = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            ShowSign();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            HideSign();
        }
    }

    private void Start()
    {
        HideSign(); 
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {

        }
    }

    private void ShowSign()
    {
        signObject.SetActive(true); 
    }

    private void HideSign()
    {
        signObject.SetActive(false); 
    }
}
