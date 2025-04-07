using UnityEngine;
using UnityEngine.UI;

public class mainScreenScript : MonoBehaviour
{
    [SerializeField] private Button exit;
    [SerializeField] private Button back;
    [SerializeField] private Button guide;
    [SerializeField] private Button guideBack;

    [SerializeField] private GameObject logo;
    [SerializeField] private GameObject guidePageParent;

    void Start()
    {
        back.onClick.AddListener(backButton);
        guide.onClick.AddListener(guidePage);
        guideBack.onClick.AddListener(guidePageReturn);
        exit.onClick.AddListener(exitGame);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void backButton()
    {
        exit.gameObject.SetActive(true);
        logo.gameObject.SetActive(true);
        guide.gameObject.SetActive(true);
    }

    public void guidePage()
    {
        guidePageParent.SetActive(true);
    }

    public void guidePageReturn()
    {
        guidePageParent.SetActive(false);
    }
}
