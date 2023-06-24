using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorTrigger : MonoBehaviour
{
    [SerializeField] private Animator doorAnim = null;
    [SerializeField] private AnimationClip openDoorClip = null;
    [SerializeField] private AnimationClip closeDoorClip = null;
    [SerializeField] private bool openDoor = false;
    [SerializeField] private bool closeDoor = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            openDoor = true;
                doorAnim.Play(openDoorClip.name, 0, 0.0f);
                Debug.Log("sa");
            if (closeDoorClip != null)
            {
                closeDoor = false;
                doorAnim.Play(closeDoorClip.name, 0, 0.0f);
                Debug.Log("saasasasa");
            }
        }
    }
}
