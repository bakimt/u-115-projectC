using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeQuaImage : MonoBehaviour
{
    public GameObject[] background;
    public string[] qualityLevels; // Array to store the names of quality levels (Low, Medium, High, etc.)
    int index;

    void Start()
    {
        index = 0;
        UpdateGraphicsSettings();
    }

    void UpdateGraphicsSettings()
    {
        QualitySettings.SetQualityLevel(index, true);
    }

    void Update()
    {
        if (index >= background.Length) index = background.Length - 1;
        if (index < 0) index = 0;

        for (int i = 0; i < background.Length; i++)
        {
            background[i].gameObject.SetActive(i == index);
        }
    }

    public void Next()
    {
        index += 1;
        UpdateGraphicsSettings();
    }

    public void Prev()
    {
        index -= 1;
        UpdateGraphicsSettings();
    }
}
