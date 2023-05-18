using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ShopManager : MonoBehaviour
{
    public TMP_Text coinUI;
    public Player player;
    public ShopItemSO[] shopItemsSO;
    public ShopTemplate[] shopPanels;
    public GameObject[] shopPanelsGO;
    public Button[] myPurchaseBtns;
    public Inventory inventory;
    public InventoryInteraction inventoryInteraction;


    void Start()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
            shopPanelsGO[i].SetActive(true);
        LoadPanels();
        //CheckPurchaseable();

        inventory = FindObjectOfType<Inventory>();
    }

    
    void Update()
    {
        coinUI.text = "Coins: " + player.coins.ToString();
        
    }

    public void LoadPanels()
    {
        for(int i = 0; i< shopItemsSO.Length; i++)
        {
            shopPanels[i].title.text = shopItemsSO[i].item.lootName;
            shopPanels[i].description.text = shopItemsSO[i].description;
            shopPanels[i].cost.text = "Coins: " + shopItemsSO[i].baseCost.ToString();
            shopPanels[i].icon = shopItemsSO[i].icon;

        }
    }
    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (player.coins >= shopItemsSO[i].baseCost)
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }
    }

    public void PurchaseItem(int btnNo)
    {
        if (player.coins >= shopItemsSO[btnNo].baseCost)
        {
            if (!shopItemsSO[btnNo].canPlayerHaveMulitiple && inventory.Check(shopItemsSO[btnNo].item)) return;

            player.coins = player.coins - shopItemsSO[btnNo].baseCost;
            coinUI.text = "Coins: " + player.coins.ToString();
            inventory.Add(shopItemsSO[btnNo].item);
            inventoryInteraction.SpendCoins(shopItemsSO[btnNo].baseCost, shopItemsSO[btnNo].item);
            //CheckPurchaseable();
        }
        
    }
}
