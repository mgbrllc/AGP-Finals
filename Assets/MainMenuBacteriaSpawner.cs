using System.Collections;
using UnityEngine;

public class MainMenuBacteriaSpawner : MonoBehaviour
{
    [Header("Bacteria Prefabs")]
    public GameObject[] bacteriaPrefabs;

    [Header("Spawn Area")]
    public float minX = -2f;
    public float maxX = 2f;
    public float minY = -5f;
    public float maxY = 5f;

    [Header("Spawn Settings")]
    public float spawnInterval = 1.5f; // Time between spawns
    public int maxBacteria = 30;       // Limit on-screen clutter

    private int currentBacteriaCount = 0;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            if (currentBacteriaCount < maxBacteria)
            {
                SpawnBacteria();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnBacteria()
    {
        Vector2 spawnPos = new Vector2(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY)
        );

        GameObject prefab = bacteriaPrefabs[Random.Range(0, bacteriaPrefabs.Length)];
        GameObject spawned = Instantiate(prefab, spawnPos, Quaternion.identity);

        // Optional: disable physics/colliders if it's just for visuals
        Collider2D col = spawned.GetComponent<Collider2D>();
        if (col) col.enabled = false;

        Rigidbody2D rb = spawned.GetComponent<Rigidbody2D>();
        if (rb)
        {
            rb.gravityScale = 0;
            rb.linearVelocity = Random.insideUnitCircle * 0.5f; // gentle floating
            rb.linearDamping = 1f;
        }

        currentBacteriaCount++;
        Destroy(spawned, 10f); // auto-despawn after 10s
        StartCoroutine(DecreaseCountAfter(10f));
    }

    IEnumerator DecreaseCountAfter(float delay)
    {
        yield return new WaitForSeconds(delay);
        currentBacteriaCount--;
    }
}
