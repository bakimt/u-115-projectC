using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class labirentdedeesyalari : MonoBehaviour
{
    private static int glassesCount = 0;
    private static int stickCount = 0;
    private static int capCount = 0;
    public ProgressBar bar;
    public string targetSceneName = "LevelMezarlik 3"; 

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            string collidedObjectName = gameObject.name; 

            
            if (collidedObjectName == "Glasses")
            {
                glassesCount++;
            }
            else if (collidedObjectName == "Stick")
            {
                stickCount++;
            }
            else if (collidedObjectName == "Cap")
            {
                capCount++;
            }

            Destroy(gameObject); 
            bar.Add(1);

            if (bar.currentValue >= 3) 
            {
                SceneManager.LoadScene(targetSceneName);
            }
        }
    }
}