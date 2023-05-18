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

    private void Start()
    {
        inventory = GetComponent<Inventory>();
        playerRef = FindObjectOfType<Player>();
        playerMovRef = FindObjectOfType<PlayerMovement>();
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
            else return;
        }
        if (itemSpent.lootName == bootsPrefab.lootName) EquipBoots();
    }
    public void EquipBoots()
    {
        if (inventory.Check(bootsPrefab))
        {
            playerMovRef.SetPlayerSpeed(playerMovRef.GetPlayerSpeed() * 1.10f);
            playerMovRef.SetPlayerSpeedDefault(playerMovRef.GetPlayerSpeed() * 1.10f);
            Debug.Log(playerMovRef.GetPlayerSpeed());
            Debug.Log(playerMovRef.GetPlayerSpeed() * 1.10f);
        }
    }
}
