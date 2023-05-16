using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class InventoryItem
{
    public Loot itemData;
    public int stackSize;


    public InventoryItem(Loot item)
    {
        itemData = item;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
    }

    public void RemoveFromStack()
    {
        stackSize--;
    }
}