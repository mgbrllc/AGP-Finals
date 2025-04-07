using System.Collections;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    [Header("Map Spawn Area")]
    public float minX = -20f;
    public float maxX = 20f;
    public float minY = -5f;
    public float maxY = 15f;

    [Header("Grid Settings")]
    public int gridColumns = 5;
    public int gridRows = 5;

    [Header("Spawn Settings")]
    public float startSpawnDelay = 0f;
    public float minSpawnDelay = 0.1f;
    public float spawnAccelerateRate = 0.05f; // How fast it speeds up

    private float currentSpawnDelay;
    private float timeSinceLastSpawn = 0f;

    void Start()
    {
        currentSpawnDelay = startSpawnDelay;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(currentSpawnDelay);
            SpawnEnemy();

            // Reduce spawn delay over time until it hits the minimum
            currentSpawnDelay = Mathf.Max(minSpawnDelay, currentSpawnDelay - spawnAccelerateRate);
        }
    }

    void SpawnEnemy()
    {
        // Calculate grid cell size
        float cellWidth = (maxX - minX) / gridColumns;
        float cellHeight = (maxY - minY) / gridRows;

        // Pick a random grid cell
        int gridX = Random.Range(0, gridColumns);
        int gridY = Random.Range(0, gridRows);

        // Spawn position within that cell with slight offset
        float spawnX = minX + (gridX * cellWidth) + Random.Range(-0.5f, 0.5f);
        float spawnY = minY + (gridY * cellHeight) + Random.Range(-0.5f, 0.5f);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        // Randomly select an enemy prefab
        GameObject[] enemyOptions = { enemy1, enemy2, enemy3, enemy4 };
        GameObject chosenEnemy = enemyOptions[Random.Range(0, enemyOptions.Length)];

        if (chosenEnemy != null)
        {
            GameObject spawnedBacteria = Instantiate(chosenEnemy, spawnPosition, Quaternion.identity);
            CollideBacteria bScript = spawnedBacteria.GetComponent<CollideBacteria>();
            if (bScript != null)
            {
                // Assign additional logic if needed
            }
        }
    }
}
