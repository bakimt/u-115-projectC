using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDoorOpen : MonoBehaviour
{
    public GameObject doorMesh;
    public GameObject pressPlate;
    void Start()
    {
        doorMesh.GetComponent<Animator>().SetBool("closeDoor", false);
        doorMesh.GetComponent<Animator>().SetBool("openDoor", false);
        pressPlate.GetComponent<Animator>().SetBool("pressedPlate", false);
        pressPlate.GetComponent<Animator>().SetBool("upPlate", false);
    }

    void OnTriggerEnter(Collider other)
    {
        pressPlate.GetComponent<Animator>().SetBool("upPlate", false);
        doorMesh.GetComponent<Animator>().SetBool("closeDoor", false);
        if (other.CompareTag("Box"))
        {
            doorMesh.GetComponent<Animator>().SetBool("openDoor", true);
            pressPlate.GetComponent<Animator>().SetBool("pressedPlate", true);
        }  
    }
}
