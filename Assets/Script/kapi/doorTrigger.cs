using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject kapiMesh;
    private bool isPlayerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            kapiMesh.GetComponent<Animator>().Play("OpenDoor");
            Debug.Log("Girdin");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            Debug.Log("Çıktın");
        }
    }

    private void Update()
    {
        if (!isPlayerInside)
        {
            kapiMesh.GetComponent<Animator>().Play("CloseDoor");
        }
    }
}