using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCSystem : MonoBehaviour
{
    public GameObject d_template;
    public GameObject canva;
    bool player_detection = false;
    void Update(){
        if(player_detection && Input.GetKeyDown(KeyCode.F) && !MovementRelative.dialogue){
            canva.SetActive(true);
            MovementRelative.dialogue = true;
            NewDialogue("Hi");
            NewDialogue("I am Beyza.");
            NewDialogue("İnş bu dialoglar olacak");
            canva.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other){

        if(other.name == "kiz-mesh@Happy Idle"){
            player_detection = true;
        }
    }

    void NewDialogue(string text)
    {
        GameObject template_clone = Instantiate(d_template, d_template.transform);
        template_clone.transform.parent = canva.transform;
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }

    private void OnTriggerExit(Collider other){
        player_detection = false;
    }
}
