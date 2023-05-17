using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInteraction : MonoBehaviour
{
    Inventory inventory;
    Player playerRef;
    public Loot healPotPrefab;
    public Loot coinPrefab;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
        playerRef = FindObjectOfType<Player>();
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
    public void SpendCoins(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (inventory.Check(coinPrefab))
            {
                inventory.Remove(coinPrefab);
            }
            else return;
        }
    }
}
