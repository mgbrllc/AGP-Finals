using UnityEngine;
using TMPro;

public class CollideBacteria : MonoBehaviour
{
    public GameObject uiPopup; // Laser visual
    private bool isCollidingWithBacteria = false;
    private Collider2D currentBacteria;
    int counter1, counter2;
    public TextMeshProUGUI task1Text, task2Text;
    public GameObject bacteriaPrefab;

    private void Start()
    {
        //taskText1();
    }

    void Update()
    { 
    //    // Show laser while holding
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        if (uiPopup != null)
    //            uiPopup.SetActive(true);
    //    }

    //    // On mouse release (fire)
    //    if (Input.GetKeyUp(KeyCode.Space))
    //    {
    //        if (uiPopup != null)
    //            uiPopup.SetActive(false);

    //        if (currentBacteria != null)
    //        {
    //            if (currentBacteria.CompareTag("BacteriaWeakSpot"))
    //            {
    //                // ✅ Correct hit
    //                Destroy(currentBacteria.gameObject);
    //                counter1--;
    //                taskText1();
    //            }
    //            else if (currentBacteria.CompareTag("Splitting Bacteria"))
    //            {
    //                // ✅ Wrong hit on special bacteria — split into 2
    //                Vector3 pos = currentBacteria.transform.position;
    //                Quaternion rot = currentBacteria.transform.rotation;

    //                CloneGroup cloneGroup = new CloneGroup(this);

    //                Destroy(currentBacteria.gameObject);
    //                GameObject clone1 = Instantiate(bacteriaPrefab, pos + Vector3.left * 0.5f, rot);
    //                GameObject clone2 = Instantiate(bacteriaPrefab, pos + Vector3.right * 0.5f, rot);

    //                clone1.tag = "Bacteria"; // make clones behave like normal bacteria
    //                clone2.tag = "Bacteria";

    //                clone1.AddComponent<BacteriaClones>().parentGroup = cloneGroup;
    //                clone2.AddComponent<BacteriaClones>().parentGroup = cloneGroup;
    //            }
    //            else if (currentBacteria.CompareTag("Bacteria"))
    //            {
    //                // ✅ Normal bacteria — destroy normally
    //                Destroy(currentBacteria.gameObject);
    //                counter1--;
    //                taskText1();
    //            }

    //            currentBacteria = null;
    //            isCollidingWithBacteria = false;
    //        }
    //    }
    //}

    //void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.CompareTag("Bacteria") || other.CompareTag("BacteriaWeakSpot") || other.CompareTag("Splitting Bacteria"))
    //    {
    //        isCollidingWithBacteria = true;
    //        currentBacteria = other;
    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("Bacteria") || other.CompareTag("BacteriaWeakSpot") || other.CompareTag("Splitting Bacteria"))
    //    {
    //        isCollidingWithBacteria = false;
    //        currentBacteria = null;

    //        if (uiPopup != null)
    //            uiPopup.SetActive(false);
    //    }
    //}

    //void taskText1()
    //{
    //    if (counter1 != null)
    //    {
    //        counter1--;
    //    }
    //}

    //public void OnBothClonesDestroyed()
    //{
    //    counter1--;
    //    taskText1();
    }

    public class CloneGroup
    {
        private int remainingClones = 2;
        private CollideBacteria mainScript;

        public CloneGroup(CollideBacteria script)
        {
            mainScript = script;
        }

    }
}
