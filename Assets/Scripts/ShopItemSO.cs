using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ShopMenu", menuName = "Scriptable Objects/New Shop Item", order = 1)]
public class ShopItemSO : ScriptableObject
{
    public Loot item;
    public string description;
    public int baseCost;
    public Image icon;
    public bool canPlayerHaveMulitiple;
}
