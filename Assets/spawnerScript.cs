using System.Collections;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject enemy1;
    public GameObject enemy2;
    

    [Header("Spawn Area")]
    public float minX = -5f;
    public float maxX = 5f;
    public float minY = 0f;
    public float maxY = 10f;

    private float elapsedTime = 0f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Determine current spawn time
            float currentSpawnTime = (elapsedTime < 3f) ? 0.1f : 1f;

            // Spawn logic
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector2 spawnPosition = new Vector2(randomX, randomY);

            int enemyIndex = Random.Range(1, 3);
            GameObject chosenEnemy = null;

            switch (enemyIndex)
            {
                case 1: chosenEnemy = enemy1; break;
                case 2: chosenEnemy = enemy2; break;
            }

            if (chosenEnemy != null)
                Instantiate(chosenEnemy, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(currentSpawnTime);
            elapsedTime += currentSpawnTime;
        }
    }
}
//