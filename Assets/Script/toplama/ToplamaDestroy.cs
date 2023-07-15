using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                Debug.Log("kopru olacak");
            }
        }
    }
}