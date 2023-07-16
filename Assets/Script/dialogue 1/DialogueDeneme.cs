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
           
            "you must wonder where you are or how did you even get here",
            "welcome to the realm of death and life",
            "I'm Necrosia, a soul that passed away almost 100 years ago I've been here for a while now ",
            "I looked like you before...",
            "full of life and joy",
            "getting stuck here didn't treat me very nicely",
            "that's why I want to help you.. so you don't end up like me",
            "This realm.. is not what every spirit goes through in their death journey",
            "you're a special one my child, just like I was ",
            "But I failed their tests.. I couldn't save my family from this realm and it's tests. and I'm in agony because of it everyday",
            "I don't want you to end up like me I don't want you to go through what I went through",
            "so I want to help you",
            "your first mission, first one you should save is your cat, Luna",
            "go up the path next to the church",
            "there's a teleport point, it will teleport you to the necessary location",
            "I believe in you, my child,",
            
            
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
