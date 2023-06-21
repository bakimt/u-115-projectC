using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toplama : MonoBehaviour
{
    [SerializeField] List<GameObject> _toggleObjects;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            foreach(var toggleObject in _toggleObjects)
                toggleObject.SetActive(false);
        }

        if(Input.GetButtonDown("Fire2"))
        {
            foreach(var toggleObject in _toggleObjects)
                toggleObject.SetActive(true);
        }
    }
}
