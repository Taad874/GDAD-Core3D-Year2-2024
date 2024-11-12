using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class EnemySpawner : MonoBehaviour
{
    public EnemyData[] enemyTypes; // Array of enemy data types (configured with EnemyData assets)
    public Vector3 spawnArea; // Dimensions (x, y, z) of the spawn area
    public float startDelay = 1f; // Initial delay before spawning begins
    public float minSpawnInterval = 2f; // Minimum interval between spawns
    public float maxSpawnInterval = 5f; // Maximum interval between spawns
    public int maxSpawnedObjects = 100; // Maximum number of active spawned enemies
    private List<EnemyBase> spawnedEnemies = new List<EnemyBase>(); // Tracks all spawned enemies
    private void Start()
    {
        StartCoroutine(Spawner());
    }
    private IEnumerator Spawner()
    {
        yield return new WaitForSeconds(startDelay);
        // Repeatedly spawn enemies at random intervals until reaching maxSpawnedObjects
        while (spawnedEnemies.Count < maxSpawnedObjects)
        {
            SpawnRandomEnemy();
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    private void SpawnRandomEnemy()
    {
        if (enemyTypes.Length == 0) return; // Ensure there are enemy types to spawn
                                            // Pick a random enemy type from the array
        int randomIndex = Random.Range(0, enemyTypes.Length);
        EnemyData selectedEnemyData = enemyTypes[randomIndex];
        // Generate a random spawn position within the spawn area
        Vector3 randomPosition = new Vector3(
        Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
        Random.Range(0, spawnArea.y),
        Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
        );
        // Use the factory to create the enemy
        EnemyBase enemy = EnemyFactory.CreateEnemy(selectedEnemyData, randomPosition);
        if (enemy != null)
        {
            spawnedEnemies.Add(enemy); // Add the spawned enemy to the tracking list
        }
    }
}