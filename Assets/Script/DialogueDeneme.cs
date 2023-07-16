using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueDeneme : MonoBehaviour
{
    public Canvas canvas;
    public GameObject textObject; // Text elemanının bulunduğu objeyi buraya atayın
    private Text dialogueText; // Text elemanını tutacak değişken
    private bool isInRange = false;
    private string[] dialogueArray;
    private int currentIndex = 0;

    void Start()
    {
        // Text elemanını alıyoruz
        dialogueText = textObject.GetComponent<Text>();

        // Dizi içerisine metinleri ekleyin
        dialogueArray = new string[]
        {
            "Merhaba, benim adım NPC.",
            "Oyun dünyasına hoş geldiniz!",
            "Keşfetmek için etrafı dolaşın ve eğlenin!"
            // Dilediğiniz kadar metin ekleyebilirsiniz
        };
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
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
        // İşlemi sonlandırma veya istediğiniz başka bir şey yapabilirsiniz.
    }
}
