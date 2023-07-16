using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueDeneme : MonoBehaviour
{
    public Canvas canvas;
    public GameObject textObject;
    private Text dialogueText;
    private bool isInRange = false;
    private string[] dialogueArray;
    private int currentIndex = 0;

    void Start()
    {
        dialogueText = textObject.GetComponentInChildren<Text>();

        dialogueArray = new string[]
        {
            "kardeşim buralar sıkıntılı yerler dikkat et kendine keserler götünü",
            "şurda şerafettin diye bir piç var git onu ordan çıkar boğulmuş gelemiyor götü yememiş",
            "bide sürekli yukarı bak diyen bi moruk var onu da al gel sonra ne bok yersen ye"
        };
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            canvas.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        isInRange = false;
        EndDialogue();
    }

    void Update()
    {
        if (isInRange && Input.GetMouseButtonDown(0))
        {
            if (currentIndex < dialogueArray.Length)
            {
                dialogueText.text = dialogueArray[currentIndex];
                currentIndex++;
            }
            else
            {
                EndDialogue();
            }
        }
    }

    void EndDialogue()
    {
        canvas.gameObject.SetActive(false);
    }
}
