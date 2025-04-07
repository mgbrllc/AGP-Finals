using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public GameObject image1;

    void Start()
    {
        button1.onClick.AddListener(OnButton1Click);
        button2.onClick.AddListener(OnButton2Click);

        // Start with image and button2 disabled
        image1.SetActive(false);
        button2.interactable = false;
    }

    void OnButton1Click()
    {
        image1.SetActive(true);              // Enable image
        button2.interactable = true;         // Enable button2
    }

    void OnButton2Click()
    {
        image1.SetActive(false);             // Disable image
        button2.interactable = false;        // Disable itself
    }
}
