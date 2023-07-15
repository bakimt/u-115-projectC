using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject actorObject;
     public GameObject textObject;
    
    
    public TextMeshProUGUI actorName;
   public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;
    
    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage=0;

    public void OpenDialogue(Message[] messages, Actor[] actors){
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;

        Debug.Log("Started conversations messages:" + messages.Length);
        DisplayMessage();
    }

    void DisplayMessage(){
      Message messageToDisplay = currentMessages[activeMessage];
      messageText.text=messageToDisplay.message;

      Actor actorToDisplay=currentActors[messageToDisplay.actorId];
      actorName.text=actorToDisplay.name;
    }
    public void NextMessage(){
      activeMessage++;
      if(activeMessage < currentMessages.Length) {
        DisplayMessage();
      } else{
          Debug.Log("Conversation Ended");
      }

    }
    void Start()
    {
      actorName = actorObject.GetComponent<TextMeshProUGUI>();  
      messageText = textObject.GetComponent<TextMeshProUGUI>();  
    }
    

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.E)) {
            NextMessage();
         }  
    }
}
