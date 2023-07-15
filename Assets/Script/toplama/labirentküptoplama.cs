using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class labirentküptoplama : MonoBehaviour
{
    private static int destroyCount = 0;
    public ProgressBar bar;
    public string targetSceneName; 

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            destroyCount++;
            bar.Add(1);

            if (destroyCount == 3)
            {
                SceneManager.LoadScene("LevelMezarlik 2");
            }
        }
    }
}