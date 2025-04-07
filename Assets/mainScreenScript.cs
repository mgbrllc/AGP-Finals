using UnityEngine;
using UnityEngine.UI;

public class mainScreenScript : MonoBehaviour
{
    [SerializeField] private Button levelSelect;
    [SerializeField] private Button exit;
    [SerializeField] private Button back;
    [SerializeField] private Button guide;
    [SerializeField] private Button guideBack;

    [SerializeField] private GameObject logo;
    [SerializeField] private GameObject levelSelectParent;
    [SerializeField] private GameObject guidePageParent;

    void Start()
    {
        levelSelect.onClick.AddListener(LevelSelection);
        back.onClick.AddListener(backButton);
        guide.onClick.AddListener(guidePage);
        guideBack.onClick.AddListener(guidePageReturn);
        exit.onClick.AddListener(exitGame);
    }

    public void LevelSelection()
    {
        if (levelSelectParent != null)
            levelSelectParent.SetActive(true);

        levelSelect.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
        logo.gameObject.SetActive(false);
        guide.gameObject.SetActive(false);

    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void backButton()
    {
        levelSelectParent.gameObject.SetActive(false);
        levelSelect.gameObject.SetActive(true);
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
