using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class labirentküptoplama : MonoBehaviour
{
    private static int destroyCount = 0;
    public ProgressBar bar;
    public string targetSceneName; // Hedef sahnenin adını tutan değişken

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            bar.Add(1);

            if (other.gameObject.tag == "mezarlik") // Karakterin colliderı ile etkileşim sağlandığında
        {
            SceneManager.LoadScene("LevelMezarlik");
        }
        }
    }
}
