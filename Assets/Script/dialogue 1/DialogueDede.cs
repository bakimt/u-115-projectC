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
           

             "My brave girl! you found me! If you were a little more late I would've forgetten that you have even existed!",
              "This place... it does strange things to me Zephyra I feel lost, I feel like I miss something but I don't even know what it is",
               "We should head on our journey, to found ourselves, our purpose, so we don't feel lost anymore ",
                "but before heading down our journey, I've lost my hat and my walking stick",
                 "without my walking stick I can't walk to where we are headed next and without my hat...",
                  "Well I suppose I can live without my hat but the hat has sentimental value... and of course it makes me look even more handsome than I already am",
                   "You should head back to the labyrinth I've lost them there",
                    "You got this my little girl we are so close to eternal happiness",
                     "I love you",

        
           
            
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
