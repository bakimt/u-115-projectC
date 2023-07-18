using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScene : MonoBehaviour
{
    public string toLoad;
    public float timer = 138f;
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Application.LoadLevel(toLoad);
        }
    }

    public void GameMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
