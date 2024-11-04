using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;         // The enemy prefab to spawn
    public int enemiesPerWave = 10;        // Number of enemies to spawn per wave
    public float timeBetweenEnemies = 1f;  // Time delay between spawning each enemy
    public float timeBetweenWaves = 5f;    // Time delay between each wave

    private Vector3 floorSize;
    private int enemiesSpawned = 0;        // Tracks how many enemies have been spawned
    private int totalEnemies;              // Total number of enemies to spawn, from GameSettings

    void Start()
    {
        // Get the size of the Floor_Cube based on its local scale
        floorSize = GetComponent<Renderer>().bounds.size;

        // Get the total number of enemies from GameSettings
        totalEnemies = GameSettings.enemyCount;

        // Start the enemy spawning process
        StartCoroutine(SpawnWaves());
    }

    // Coroutine to handle enemy spawning in waves
    IEnumerator SpawnWaves()
    {
        while (enemiesSpawned < totalEnemies)
        {
            for (int i = 0; i < enemiesPerWave && enemiesSpawned < totalEnemies; i++)
            {
                SpawnEnemy();
                enemiesSpawned++;
                yield return new WaitForSeconds(timeBetweenEnemies); // Delay between spawning each enemy
            }

            // After each wave, wait for the specified time between waves
            Debug.Log("Wave completed. Waiting for next wave...");
            yield return new WaitForSeconds(timeBetweenWaves);
        }

        Debug.Log("All enemies spawned.");
    }

    void SpawnEnemy()
    {
        // Generate a random X and Z position within the floor's size
        float randomX = Random.Range(-floorSize.x / 2, floorSize.x / 2);
        float randomZ = Random.Range(-floorSize.z / 2, floorSize.z / 2);

        // Spawn the enemy slightly above the floor at a constant height
        Vector3 spawnPosition = new Vector3(randomX, 1f, randomZ) + transform.position;

        // Instantiate the enemy prefab at the calculated position
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
