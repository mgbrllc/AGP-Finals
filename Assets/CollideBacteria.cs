using UnityEngine;

public class CollideBacteria : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("kajsdh");
        if (collision.CompareTag("Bacteria"))
        {
            Debug.Log("Colliding!");
            Destroy(collision.gameObject);
        }
    }
}
