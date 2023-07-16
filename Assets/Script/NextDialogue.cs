using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialog : MonoBehaviour
{
    int index = 2;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && transform.childCount > 1)
        {
            if(MovementRelative.dialogue)
            {
                transform.GetChild(index).gameObject.SetActive(true);
                index +=1;
                if(transform.childCount == index)
                {
                    index = 2;
                    MovementRelative.dialogue = false;
                }
            }
            else
            {
                gameObject.SetActive(false);

            }
        }
    }
}
