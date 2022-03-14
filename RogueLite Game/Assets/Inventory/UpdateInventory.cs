using System.Collections;       // Namespace references that the script can use
using System.Collections.Generic;
using UnityEngine;
using TMPro;        // Used to access and modify aspects of a TextMesh Pro

public class UpdateInventory : MonoBehaviour        // The UpdateInventory class will use features from the MonoBehaviour class
{
    public InventoryObject inventory;       // A variable which will be used to access Inventory functionalities
    // Used to access all the objects and their totals
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    
    void Start()        // Start is called before the first frame update
    {
        AddObject();        // Starts the AddObject function
    }

    void Update()       // Update is called once per frame
    {
        UpdateDisplay();        // Starts the UpdateDisplay function
    }

    public void AddObject()         // A function which will be used to add items to the list on startup
    {
        for (int i = 0; i < inventory.container.Count; i++)         // A for loop that will continue until it's gone through all items
        {
            var obj = Instantiate(inventory.container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);        // Visually adds the item
            obj.GetComponentInChildren<TextMeshProUGUI>().text = " ";       // Changes the text mesh of the item to blank
            itemsDisplayed.Add(inventory.container[i], obj);        // Adds the object to the inventory list
        }
    }

    public void UpdateDisplay()         // A function that will be run every frame to update the visual inventory with any new items
    {
        for (int i = 0; i < inventory.container.Count; i++)         // A for loop that will go through all the currently obtained items
        {
            if (itemsDisplayed.ContainsKey(inventory.container[i]))         // Checks if the current item has been displayed yet
            {
                if (inventory.container[i].amount > 1)      // Checks if the total amount is over 1
                {
                    // Changes the text mesh to total amount of the item
                    itemsDisplayed[inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("0");
                }
                else        // Will keep the text mesh empty instead of showing a "1"
                {
                    itemsDisplayed[inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text = " ";        // Changes the text mesh of the item to blank
                }
            }
            else        // Triggers if the item hadn't been previously  displayed
            {
                var obj = Instantiate(inventory.container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);        // Visually adds the item
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString(" ");       // Changes the text mesh of the item to blank
                itemsDisplayed.Add(inventory.container[i], obj);        // Updates the object in the inventory list
            }
        }
    }
}
