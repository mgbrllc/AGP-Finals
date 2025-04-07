using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Reflection.Emit;

public class level2Script : MonoBehaviour
{
    public GameObject uiPopup; // Laser visual
    private bool isCollidingWithBacteria = false;
    private Collider2D currentBacteria;
    int counter1, counter2, counter3, counterLimit;
    float timer;
    public TextMeshProUGUI task1Text, task2Text, task3Text, timerText;
    public GameObject bacteriaPrefab;

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
        counter1 = 4;
        counter2 = 8;
        counter3 = 10;
        timer = 120f;
        UpdateTimer();
        UpdateTaskText();
    }

    void Update()
    {
        UpdateTimer();
        timer -= Time.deltaTime;

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
                if (currentBacteria.CompareTag("bacteria1"))
                {
                    Destroy(currentBacteria.gameObject);
                    counter1--;
                    timer += 3;
                    UpdateTaskText();
                }
                else if (currentBacteria.CompareTag("bacteria2"))
                {
                    Destroy(currentBacteria.gameObject);
                    counter2--;
                    timer += 1;
                    UpdateTaskText();
                }
                else if (currentBacteria.CompareTag("splitting bacteria"))
                {
                    Vector3 pos = currentBacteria.transform.position;
                    Quaternion rot = currentBacteria.transform.rotation;

                    Destroy(currentBacteria.gameObject);

                    foreach (Vector3 offset in new[] { Vector3.left * 0.5f, Vector3.right * 0.5f })
                    {
                        GameObject clone = Instantiate(bacteriaPrefab, pos + offset, rot);
                        clone.tag = "Bacteria"; // clones are now normal bacteria
                    }
                }
                else if (currentBacteria.CompareTag("Bacteria")) // <-- Clones
                {
                    Destroy(currentBacteria.gameObject);
                    counter3--;
                    timer += 2;
                    UpdateTaskText();
                }
            }
        }
        
        if (counter1 <= 0 && counter2 <= 0 && counter3 <= 0)
        {
            winScreenParent.gameObject.SetActive(true);
        }
        else if (timer <= 0 && (counter1 != 0 || counter2 != 0 || counter3 != 0))
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
        if (task3Text != null)
        {
            task3Text.text = counter3 + "";
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bacteria1") ||
            other.CompareTag("bacteria2") ||
            other.CompareTag("splitting bacteria") ||
            other.CompareTag("Bacteria")) // <-- Clones
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
    public class CloneGroup
    {
        private level2Script owner;

        public CloneGroup(level2Script script)
        {
            owner = script;
        }

        public void NotifyCloneDestroyed()
        {
            Debug.Log("Clone destroyed. Owner: " + owner.name);
        }
    }

}
  