using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInteraction : MonoBehaviour
{
    Inventory inventory;
    Player playerRef;
    PlayerMovement playerMovRef;
    public Loot healPotPrefab;
    public Loot coinPrefab;
    public Loot bootsPrefab;
    public Achievements[] achievements;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
        playerRef = GameManagement.player;
        playerMovRef = GameManagement.playerMovement;
        //achievements = FindObjectsOfType<Achievements>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) ConsumeHealPotion();
    }
    void ConsumeHealPotion()
    {
        if (inventory.Check(healPotPrefab) && playerRef.maxHealth != playerRef.Health)
        {
            playerRef.Heal(1f);
            inventory.Remove(healPotPrefab);
        }
    }
    public void SpendCoins(int amount, Loot itemSpent)
    {
        for (int i = 0; i < amount; i++)
        {
            if (inventory.Check(coinPrefab))
            {
                inventory.Remove(coinPrefab);
            }
            //else return;
        }
        if (itemSpent.lootName == bootsPrefab.lootName)
        {
            EquipBoots();
            achievements[0].didPlayerBuyBoots = true;
            achievements[1].didPlayerBuyBoots = true;
        }
        if (itemSpent.lootName == healPotPrefab.lootName)
        {
            achievements[0].didPlayerBuyPotion = true;
            achievements[1].didPlayerBuyPotion = true;
        }
    }
    public void EquipBoots()
    {
        playerMovRef.SetPlayerSpeed(playerMovRef.GetPlayerSpeed() * 1.10f);
        playerMovRef.SetPlayerSpeedDefault(playerMovRef.GetPlayerSpeed() * 1.10f);
    }
}
