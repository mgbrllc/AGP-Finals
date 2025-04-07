using UnityEngine;

public class LaserScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");
    }

    private void Update()
    {
        Debug.Log("Start");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("kajsdh");
        if (collision.CompareTag("Bacteria"))
        {
            Debug.Log("Colliding!");
        }
    }
}
