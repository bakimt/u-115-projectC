using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class CubeInteraction : MonoBehaviour
{
    public string targetSceneName; // Hedef sahnenin adını tutan değişken

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "kopru") // Karakterin colliderı ile etkileşim sağlandığında
        {
            SceneManager.LoadScene("LevelKopru"); // Hedef sahneyi yükle
        }
        if (other.gameObject.tag == "meydan") // Karakterin colliderı ile etkileşim sağlandığında
        {
            SceneManager.LoadScene("LevelMeydan"); // Hedef sahneyi yükle
        }
        if (other.gameObject.tag == "mezarlik") // Karakterin colliderı ile etkileşim sağlandığında
        {
            SceneManager.LoadScene("LevelMezarlik");
        }

    }

}