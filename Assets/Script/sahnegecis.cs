using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class CubeInteraction : MonoBehaviour
{
    public string targetSceneName; // Hedef sahnenin adını tutan değişken

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LevelMezarlik 1") // Karakterin colliderı ile etkileşim sağlandığında
        {
            SceneManager.LoadScene("Labirent 1"); // Hedef sahneyi yükle
        }
        if (other.gameObject.tag == "LevelMezarlık 3") // Karakterin colliderı ile etkileşim sağlandığında
        {
            SceneManager.LoadScene("LevelMeydan"); // Hedef sahneyi yükle
        }    
    }

}