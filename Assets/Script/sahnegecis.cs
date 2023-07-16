using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class CubeInteraction : MonoBehaviour
{
    public string targetScene;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(targetScene);
        }
    }
}

