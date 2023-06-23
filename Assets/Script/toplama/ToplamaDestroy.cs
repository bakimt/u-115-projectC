using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ToplamaDestroy : MonoBehaviour
{
    private static int destroyCount = 0;
    public ProgressBar bar;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            destroyCount++;
            bar.Add(1);

            if (destroyCount == 5)
            {
                Debug.Log("2 nesne yok edildi");
            }
        }
    }
}