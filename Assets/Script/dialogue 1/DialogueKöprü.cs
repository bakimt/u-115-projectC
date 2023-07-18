using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueKöprü : MonoBehaviour
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
           

            "you seem suprised about how I got here so fast",
            "getting stuck here sucks.. but it has it's own benefits... like the power of teleportation",
            "yeah I know, epic right?",
            "but let's not stray from the topic, your first mission",
            "I can't give you much information but you have to save your cat Luna ",
            "Poor Luna drowned to death in the world of the living ",
            "she was your cat, but you might not remember since the journey here can cause memory loss",
            "but that's what I'm here for.. to help you remember people you love, and save them so you can be together happily and head your journey together as a family ",
            "Luna is across the bridge but some parts of the bridge is broken you have to fix it and save Luna",
            
            
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