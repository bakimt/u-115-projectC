using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToplamaDestroy : MonoBehaviour
{
    private static int destroyCount = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            destroyCount++;

            if (destroyCount == 5)
            {
                Debug.Log("2 nesne yok edildi");
            }
        }
    }
}