using UnityEngine;
using UnityEngine.UI;

public class levelsUIScript : MonoBehaviour
{
    [SerializeField] private Button pause;
    [SerializeField] private Button back;
    [SerializeField] private Button guide;
    [SerializeField] private Button backGuide;

    [SerializeField] private GameObject pausePageParent;
    [SerializeField] private GameObject guidePageParent;

    private void Start()
    {
        pause.onClick.AddListener(pausePage);
        back.onClick.AddListener(resume);
        guide.onClick.AddListener(guidePage);
        backGuide.onClick.AddListener(resume);
    }

    void guidePage()
    {   
        pause.gameObject.SetActive(false);
        guidePageParent.SetActive(true);
    }
    void pausePage()
    {
        Time.timeScale = 0f;
        pause.gameObject.SetActive(false);
        pausePageParent.SetActive(true);
    }

    void resume()
    {
        Time.timeScale = 1f;
        pause.gameObject.SetActive(true);
        pausePageParent.SetActive(false);
        guidePageParent.SetActive(false);
    }
}
