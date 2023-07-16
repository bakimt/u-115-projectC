using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignControllerFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup1;
    [SerializeField] private CanvasGroup canvasGroup2;
    private bool isPlayerInRange = false;

    private void Start()
    {
        canvasGroup1.alpha = 1f;
        canvasGroup2.alpha = 0f;
    }

    public void Show()
    {
        canvasGroup1.alpha = 0f;
        canvasGroup2.alpha = 1f;
    }

    public void Hide()
    {
        canvasGroup1.alpha = 1f;
        canvasGroup2.alpha = 0f;
    }

    void Update()
    {
        if (isPlayerInRange)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Show();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Hide();
        }
    }
}
