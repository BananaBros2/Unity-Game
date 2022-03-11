using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateInventory : MonoBehaviour
{
    public InventoryObject inventory;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    void Start()
    {
        AddObject();
    }

    void Update()
    {
        UpdateDisplay();
    }

    public void AddObject()
    {
        for (int i = 0; i < inventory.container.Count; i++)
        {
            var obj = Instantiate(inventory.container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = " ";
            itemsDisplayed.Add(inventory.container[i], obj);
        }
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.container[i]))
            {
                if (inventory.container[i].amount > 1)
                {
                    itemsDisplayed[inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString("n0");
                }
                else
                {
                    itemsDisplayed[inventory.container[i]].GetComponentInChildren<TextMeshProUGUI>().text = " ";

                }
            }
            else
            {
                var obj = Instantiate(inventory.container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.container[i].amount.ToString(" ");
                itemsDisplayed.Add(inventory.container[i], obj);
            }
        }
    }
}
