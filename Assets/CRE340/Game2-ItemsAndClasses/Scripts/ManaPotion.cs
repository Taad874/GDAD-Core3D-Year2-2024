using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Derived class ManaPotion that inherits from Item
public class ManaPotion : Item
{
    public int manaRestoreAmount; // Amount of mana this potion restores
    public int minRestoreAmount = 20; // Minimum restore amount for random range
    public int maxRestoreAmount = 50; // Maximum restore amount for random range
                                      // Default constructor, sets the name and description of the mana potion
    public ManaPotion()
    {
        itemName = "Mana Potion";
        description = "A potion that restores mana.";
    }
    // Called when the object is instantiated
    private void Start()
    {
        // Assign a random value for manaRestoreAmount within the specified range
        manaRestoreAmount = Random.Range(minRestoreAmount, maxRestoreAmount);
        Debug.Log($"ManaPotion: Random restore amount set to {manaRestoreAmount}.");
    }
    // Override method to display specific mana potion info
    public override void DisplayInfo()
    {
        Debug.Log($"{itemName}: Restores {manaRestoreAmount} mana points.");
    }
}
