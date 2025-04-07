using UnityEngine;
using UnityEngine.UI;

public class level1UIScript : MonoBehaviour
{
    [SerializeField] private Button pause;
    [SerializeField] private Button back;
    [SerializeField] private Button guide;

    [SerializeField] private GameObject pausePageParent;

    private void Start()
    {
        pause.onClick.AddListener(pausePage);
        back.onClick.AddListener(resume);
    }

    void pausePage()
    {
        pause.gameObject.SetActive(false);
        pausePageParent.SetActive(true);
    }

    void resume()
    {
        pause.gameObject.SetActive(true);
        pausePageParent.SetActive(false);
    }
}
