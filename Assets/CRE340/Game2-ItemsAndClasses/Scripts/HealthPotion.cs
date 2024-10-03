using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Derived class HealthPotion that inherits from Item
public class HealthPotion : Item
{
    public int healthRestoreAmount; // Amount of health this potion restores
    public int minRestoreAmount = 30; // Minimum restore amount for random range
    public int maxRestoreAmount = 70; // Maximum restore amount for random range
                                      // Default constructor, sets the name and description of the health potion
    public HealthPotion()
    {
        itemName = "Health Potion";
        description = "A potion that restores health.";
    }
    // Called when the object is instantiated
    private void Start()
    {
        // Assign a random value for healthRestoreAmount within the specified range
        healthRestoreAmount = Random.Range(minRestoreAmount, maxRestoreAmount);
        Debug.Log($"HealthPotion: Random restore amount set to {healthRestoreAmount}.");
    }
    // Override method to display specific health potion info
    public override void DisplayInfo()
    {
        Debug.Log($"{itemName}: Restores {healthRestoreAmount} health points.");
    }
}
