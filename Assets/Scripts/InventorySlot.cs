using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI labelText;
    public TextMeshProUGUI stackSizeText;

    public void ClearSlot()
    {
        icon.enabled = false;
        labelText.enabled = false;
        stackSizeText.enabled = false;
    }

    public void DrawSlot(InventoryItem item)
    {
        if(item == null)
        {
            ClearSlot();
            return;
        }

        icon.enabled = true;
        icon.sprite = item.itemData.lootSprite;
        labelText.enabled = true;
        labelText.text = item.itemData.lootName;
        stackSizeText.enabled = true;

        //icon.sprite = item.itemData.icon;
        //labelText.text= item.itemData.displayName;
        stackSizeText.text = item.stackSize.ToString();
    }
}
