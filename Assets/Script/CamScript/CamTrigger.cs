using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    void Start()
    {
        cam1.gameObject.tag = "MainCamera";
        cam2.gameObject.tag = "Untagged";
        cam1.SetActive(true);
        cam2.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        cam1.gameObject.tag = "Untagged";
        cam2.gameObject.tag = "MainCamera";
        cam1.SetActive(false);
        cam2.SetActive(true);
    }
}
