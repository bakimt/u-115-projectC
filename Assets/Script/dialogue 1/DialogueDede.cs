using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueDede : MonoBehaviour
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
           
            "you did it my child your first mission, you completed it successfully",
             "I knew it, you had it in you",
            "but there's still people from your family that needs to be saved, you are their only hope",
            "and in this mission you need to save your grandfather, José",
            "you may not remember him  due to your memory loss but he had a very big impact on your life",
            "when no one was , he was there for you. ",
            "I don't want to tell you every single detail, you will remember everything once you meet him again ",
             "Look around your surroundings there should be a hill around here,and your grandfather is waiting on top of that hill ",
              "he may not remember you at first but he will remember with time",
            
            
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
