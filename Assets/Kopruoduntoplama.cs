using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kopruoduntoplama : MonoBehaviour
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

            if (destroyCount == 20)
            {
                SceneManager.LoadScene("LevelKopru 2");
            }
        }
    }
}