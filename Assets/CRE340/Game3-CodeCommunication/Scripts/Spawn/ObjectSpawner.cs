using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs; // Array of prefabs to spawn
    public Vector3 spawnArea; // x, y, z (width, height, depth) of the spawn area
    public float minSpawnInterval = 2f; // Minimum spawn interval (2 seconds)
    public float maxSpawnInterval = 5f; // Maximum spawn interval (5 seconds)
                                        // List to store references to all spawned objects
    public List<GameObject> spawnedObjects = new List<GameObject>();
    void Start()
    {
        // Start invoking the SpawnObject method at a random interval
        InvokeRepeating("SpawnRandomObject", Random.Range(minSpawnInterval, maxSpawnInterval),
        Random.Range(minSpawnInterval, maxSpawnInterval));
    }
    void SpawnRandomObject()
    {
        if (objectPrefabs.Length == 0) return; // Ensure there is something to spawn
                                               // Pick a random prefab from the array
        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject prefabToSpawn = objectPrefabs[randomIndex];
        // Generate a random position within the spawn area
        Vector3 randomPosition = new Vector3(
        Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
        Random.Range(0, spawnArea.y),
        Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
        );
        // Instantiate the prefab at the random position
        GameObject spawnedObject = Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
        // Add the newly spawned object to the list
        spawnedObjects.Add(spawnedObject);
        // Reschedule the next spawn with a new random interval
        CancelInvoke("SpawnRandomObject");
        Invoke("SpawnRandomObject", Random.Range(minSpawnInterval, maxSpawnInterval));
    }
    // Method to visualize the spawn area in the Scene view
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, spawnArea);
    }
    // Method to show the number of spawned objects in the list
    public void ShowSpawnedObjectsCount()
    {
        Debug.Log("Number of spawned objects: " + spawnedObjects.Count);
    }
}
