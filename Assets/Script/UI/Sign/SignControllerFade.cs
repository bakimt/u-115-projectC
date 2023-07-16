using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignControllerFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup1;
    [SerializeField] private CanvasGroup canvasGroup2;
    private bool isPlayerInRange = false;

    private float transitionSpeed = 1.5f;

    private void Start()
    {
        canvasGroup1.alpha = 1f;
        canvasGroup2.alpha = 0f;
    }

    public void Show()
    {
        StartCoroutine(FadeInOut(canvasGroup2, 1f));
        StartCoroutine(FadeInOut(canvasGroup1, 0f));
    }

    public void Hide()
    {
        StartCoroutine(FadeInOut(canvasGroup1, 1f));
        StartCoroutine(FadeInOut(canvasGroup2, 0f));
    }

    private IEnumerator FadeInOut(CanvasGroup canvasGroup, float targetAlpha)
    {
        float currentAlpha = canvasGroup.alpha;
        while (!Mathf.Approximately(currentAlpha, targetAlpha))
        {
            currentAlpha = Mathf.MoveTowards(currentAlpha, targetAlpha, Time.deltaTime * transitionSpeed);
            canvasGroup.alpha = currentAlpha;
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Show();
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
