using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
// The ItemSpawner script is responsible for spawning Health and Mana Potions in the scene
public class ItemSpawner : MonoBehaviour
{
    // References to the potion prefabs, to be set in the Unity Inspector
    public GameObject healthPotionPrefab; // Drag HealthPotion prefab here in the Inspector
    public GameObject manaPotionPrefab; // Drag ManaPotion prefab here in the Inspector
    public int numberOfItemsEachSide = 3; // Number of items on each side of the origin (total of 6 items)
public float spacing = 2.0f; // Distance between each item along the X-axis
                             // This method is called when the scene starts
    void Start()
    {
        SpawnHealthPotions(); // Spawn the health potions along the X-axis
        SpawnManaPotions(); // Spawn the mana potions along the X-axis
    }
    // Spawns HealthPotion instances along the X-axis, centered around the origin
    void SpawnHealthPotions()
    {
        for (int i = -numberOfItemsEachSide; i <= numberOfItemsEachSide; i++)
        {
            // Calculate the position of each potion along the X-axis with Y = -0.5 and Z = 0
            Vector3 position = new Vector3(i * spacing, -0.5f, 0);
            // Instantiate the HealthPotion prefab at the calculated position
            GameObject newHealthPotion = Instantiate(healthPotionPrefab, position, Quaternion.identity);
            // Check if the HealthPotion script is correctly attached to the instantiated prefab
            HealthPotion healthPotionItem = newHealthPotion.GetComponent<HealthPotion>();
            if (healthPotionItem != null)
            {
                // Display information about the health potion in the Console
                healthPotionItem.DisplayInfo();
            }
            else
            {
                Debug.LogWarning("The instantiated health potion does not have the HealthPotion component!");
            }
        }
    }
    // Spawns ManaPotion instances along the X-axis, centered around the origin
    void SpawnManaPotions()
    {
        for (int i = -numberOfItemsEachSide; i <= numberOfItemsEachSide; i++)
        {
            // Calculate the position of each potion along the X-axis with Y = -0.5 and Z = -4.0 (toseparate them visually)
            Vector3 position = new Vector3(i * spacing, -0.5f, -4.0f);
            // Instantiate the ManaPotion prefab at the calculated position
            GameObject newManaPotion = Instantiate(manaPotionPrefab, position, Quaternion.identity);
            // Check if the ManaPotion script is correctly attached to the instantiated prefab
            ManaPotion manaPotionItem = newManaPotion.GetComponent<ManaPotion>();
            if (manaPotionItem != null)
            {
                // Display information about the mana potion in the Console
                manaPotionItem.DisplayInfo();
            }
            else
            {
                Debug.LogWarning("The instantiated mana potion does not have the ManaPotioncomponent!");
            }
        }
    }
}

