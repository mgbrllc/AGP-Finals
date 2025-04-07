using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Reflection.Emit;

public class level1Script : MonoBehaviour
{
    public GameObject uiPopup; // Laser visual
    private bool isCollidingWithBacteria = false;
    private Collider2D currentBacteria;
    int counter1, counter2, counterLimit;
    float timer;
    public TextMeshProUGUI task1Text, task2Text, timerText;

    [SerializeField] private string UI;
    [SerializeField] private Button winLevels;
    [SerializeField] private Button winMM;
    [SerializeField] private Button loseRestart;
    [SerializeField] private Button loseMM;
    [SerializeField] private GameObject winScreenParent;
    [SerializeField] private GameObject loseScreenParent;
    [SerializeField] private GameObject timerParent;

    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip spaceSfx;



    private void Start()
    {
        counter1 = 6;
        counter2 = 10;
        counterLimit = 0;
        timer = 45f;
        UpdateTimer();
        UpdateTaskText();
    }

    void Update()
    {
        UpdateTimer();
        timer -= Time.deltaTime;

        // Show laser while holding
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (uiPopup != null)
                uiPopup.SetActive(true);

            if (sfxSource != null && spaceSfx != null)
            {
                sfxSource.PlayOneShot(spaceSfx);
            }
        }

        // On mouse release (fire)
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (uiPopup != null)
                uiPopup.SetActive(false);

            if (currentBacteria != null)
            {
                if (currentBacteria.CompareTag("bacteria1") && counter1 > counterLimit)
                {
                    Destroy(currentBacteria.gameObject);
                    counter1 = Mathf.Max(counterLimit, counter1 - 1);
                    timer += 3;
                    UpdateTaskText();
                }
                else if (currentBacteria.CompareTag("bacteria2") && counter2 > counterLimit)
                {
                    Destroy(currentBacteria.gameObject);
                    counter2 = Mathf.Max(counterLimit, counter2 - 1);
                    timer += 1;
                    UpdateTaskText();
                }
            }
        }

        if (counter1 <= 0 && counter2 <= 0)
        {
            winScreenParent.gameObject.SetActive(true);
        }
        else if (timer <= 0 && (counter1 != 0 || counter2 != 0))
        {
            loseScreenParent.gameObject.SetActive(true);
            timerParent.gameObject.SetActive(false);
        }
    }

    void UpdateTimer()
    {
 
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    void UpdateTaskText()
    {
        if (task1Text != null)
        {
            task1Text.text = counter1 + "";
        }
        if (task2Text != null)
        {
            task2Text.text = counter2 + "";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bacteria1") || other.CompareTag("bacteria2"))
        {
            isCollidingWithBacteria = true;
            currentBacteria = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == currentBacteria)
        {
            isCollidingWithBacteria = false;
            currentBacteria = null;
        }
    }

}
  