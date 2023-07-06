using System.Collections;
using System.Collections.Generic;
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
    public GameObject dedeCharacter;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            bar.Add(1);
            SceneManager.LoadScene("LevelMezarlik");
            ActivateDedeCharacterRenderer();
        }
    }

    void ActivateDedeCharacterRenderer()
    {
        SkinnedMeshRenderer meshRenderer = dedeCharacter.GetComponent<SkinnedMeshRenderer>();
        meshRenderer.enabled = true;
    }
}