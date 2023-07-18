using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueLabirent : MonoBehaviour
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
           
            "wow you made it this far, I'm proud of you my child",
            "this test the realm set up for you is kind of tricky, I'd have given more information if I could ",
            "but I'm afraid I must let you be on your own on this one my child",
            "but I may give you a little hint, a riddle so you can figure it out yourself",
            "In shadows they soar, black as night, Their cawing echoes, taking flight. Intelligent and cunning, with feathers aglow,A harbinger of omens, what am I? Do you know?",
            "they hold all the secrets you have to know for this puzzle my dear",
            "good luck",
            


            
           
            
            
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
