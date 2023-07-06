using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject actorObject;
     public GameObject textObject;
    
    
    private Text actorName;
    private Text messageText;
    private RectTransform backgroundBox;
    
    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage=0;

    public void OpenDialogue(Message[] messages, Actor[] actors){
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;

        Debug.Log("Started conversations messages:" + messages.Length);
    }
    void Start()
    {
      actorName = actorObject.GetComponent<Text>();  
      messageText = textObject.GetComponent<Text>();  
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
