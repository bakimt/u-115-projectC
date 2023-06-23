using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class BarrelInteraction : MonoBehaviour
{
    public GameObject textContainerPrefab; // Dikdörtgen metin kutusu için prefab referansı

    private GameObject textContainerInstance; // Oluşturulan metin kutusu örneği
    private Text interactText; // Metin kutusunda görünecek metin

    private bool isInteracting; // Etkileşim durumunu kontrol etmek için bool değişken

    private void Start()
    {
        CreateTextContainer();
        SetInteractText("Kitli"); // Varsayılan metni ayarla
        interactText.enabled = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInteracting = true;
            interactText.enabled = true; // Metin kutusunu görünür yap

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInteracting = false;
            interactText.enabled = false; // Metin kutusunu gizle
        }
    }

    private void Update()
    {
        if (isInteracting)
        {
            Debug.Log("sa");// Etkileşim durumunda yapılması gereken işlemler buraya yazılabilir
        }
    }

    private void CreateTextContainer()
    {
        if (textContainerInstance == null)
        {
            textContainerInstance = Instantiate(textContainerPrefab, transform.position + new Vector3(0f, 0.1f, 0f), Quaternion.identity);
            textContainerInstance.transform.SetParent(transform);

            // Metin kutusu içerisindeki Text bileşenini bul
            interactText = textContainerInstance.GetComponentInChildren<Text>();
        }
    }

    private void SetInteractText(string text)
    {
        if (interactText != null)
        {
            interactText.text = text;
        }
    }
}