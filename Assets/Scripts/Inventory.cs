using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Inventory : MonoBehaviour 
{
    public static event Action<List<InventoryItem>> OnInventoryChange;

    public List<InventoryItem> inventory = new List<InventoryItem>();
    private Dictionary<Loot, InventoryItem> itemDictionary = new Dictionary<Loot, InventoryItem>();

    private void OnEnable()
    {
        CollectibleItem.OnItemCollected += Add;
    }

    private void OnDisable()
    {
        CollectibleItem.OnItemCollected -= Add;
    }

    public void Add(Loot itemData)
    {
       if(itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.AddToStack();
            OnInventoryChange?.Invoke(inventory);
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            OnInventoryChange?.Invoke(inventory);
        }
    }

    public void Remove(Loot itemData)
    {
        if (itemDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            item.RemoveFromStack();
            if (item.stackSize == 0)
            {
                inventory.Remove(item);
                itemDictionary.Remove(itemData);
            }
            OnInventoryChange?.Invoke(inventory);
        }
    }
    public bool Check(Loot itemData)
    {
        if (itemDictionary.TryGetValue(itemData, out InventoryItem item)) return true;
        return false;
    }
}
