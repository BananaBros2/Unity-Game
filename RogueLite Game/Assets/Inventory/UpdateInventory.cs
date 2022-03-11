using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateInventory : MonoBehaviour
{
    public InventoryObject inventory;
    Dictionary<InventorySlot, GameObject> ItemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    void Start()
    {
        AddObject();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void AddObject()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = " ";
            ItemsDisplayed.Add(inventory.Container[i], obj);
        }
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (ItemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                if (inventory.Container[i].amount > 1)
                {
                    ItemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                }
                else
                {
                    ItemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = " ";

                }
            }
            else
            {
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString(" ");
                ItemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }
}
