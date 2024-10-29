using UnityEngine;
public abstract class InventoryItem : ScriptableObject
{
    public string itemName; // Name of the item
    public Sprite icon; // Icon to display in the inventory UI
    public ItemType itemType; // Category of the item (e.g., Health, Weapon, Bonus)
}
