using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Reflection.Emit;

public class level3Script : MonoBehaviour
{
    public GameObject uiPopup; // Laser visual
    private bool isCollidingWithBacteria = false;
    private Collider2D currentBacteria;
    int counter1, counter2, counter3, counter4, counterLimit;
    float timer;
    public TextMeshProUGUI task1Text, task2Text, task3Text, task4Text, timerText;
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
        counter1 = 10;
        counter2 = 5;
        counter3 = 8;
        counter4 = 12;
        timer = 200f;
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
                    UpdateTaskText();
                }
                else if (currentBacteria.CompareTag("bacteria2"))
                {
                    Destroy(currentBacteria.gameObject);
                    counter2--;
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
                    UpdateTaskText();
                }
                else if (currentBacteria.CompareTag("bacteria4"))
                {
                    jointVisualizer jointScript = currentBacteria.GetComponent<jointVisualizer>();

                    if (jointScript != null)
                    {
                        Joint2D joint = jointScript.jointToTrack;

                        if (joint != null)
                        {
                            jointScript.OnJointDestroyed(); // ?? Custom method to destroy joint + visual
                            Debug.Log("Joint destroyed! Hit again to destroy bacteria.");
                        }
                        else
                        {
                            Destroy(currentBacteria.gameObject);
                            counter4--;
                            UpdateTaskText();
                            Debug.Log("Bacteria4 destroyed after joint was broken.");
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
        if (task1Text != null) task1Text.text = counter1 + "";
        if (task2Text != null) task2Text.text = counter2 + "";
        if (task3Text != null) task3Text.text = counter3 + "";
        if (task4Text != null) task4Text.text = counter4 + "";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if  (other.CompareTag("bacteria1") ||
            other.CompareTag("bacteria2") ||
            other.CompareTag("splitting bacteria") ||
            other.CompareTag("Bacteria") ||
            other.CompareTag("bacteria4"))
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
        private MonoBehaviour owner;

        public CloneGroup(MonoBehaviour owner)
        {
            this.owner = owner;
        }

        public void NotifyCloneDestroyed()
        {
            Debug.Log("Clone destroyed. Owner: " + owner.name);
        }
    }
}
