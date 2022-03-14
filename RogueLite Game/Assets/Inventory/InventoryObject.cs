using System.Collections;       // Namespace references that the script can use
using System.Collections.Generic;
using UnityEngine;

// Creates a new tab in the create menu that can be used to make a scriptable object that will store the game items
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]

public class InventoryObject : ScriptableObject         // The InventoryObject class will use features from the ScriptableObject class
{
    public List<InventorySlot> container = new List<InventorySlot>();       // Sets the inventory as a usable variable
    public void AddItem(ItemObject _item, int _amount)      // A function used to check if there are new items needed to be added
    {
        bool hasItem = false;       // Starts a variable for keeping track if the item is new or not
        for (int i = 0; i < container.Count; i++)       // A for loop that continues until it has compared with all stored items
        {
            if (container[i].item == _item)      // Checks if the current inventory item matches with the new(?) item
            {
                container[i].AddAmount(_amount);        //  Adds the given amount to the total amount using the AddAmount function
                hasItem = true;         //  Sets the hasItem variable to true
                break;      // Exits the for loop
            }
        }
        if (!hasItem)       // Checks if the player hasn't collected the item yet
        {
            container.Add(new InventorySlot(_item, _amount));       // Adds the new item to the array using the InventorySlot function
        }
    }
}

[System.Serializable]       // Serialized sections save their values even when a script has finished
public class InventorySlot      // A seperate class for handling the item and amount variables
{
    public ItemObject item;         // A variable which will be used to inherit features used in the 'ItemObject' script
    public int amount;      // Adds a variable for keeping track of the total of an item

    public InventorySlot(ItemObject _item, int _amount)         // A function for helping to add the new item
    {
        item = _item;       // Sets the item object to the item object parameter
        amount = _amount;       // Sets the amount variable to the amount parameter
    }
    public void AddAmount(int value)        // A function for adding to existing items
    {
        amount += value;        // Adds the given value to the total amount
    }
}
