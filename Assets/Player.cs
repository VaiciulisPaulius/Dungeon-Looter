using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int health = 100;
    public int coins = 0;

    public void TakeDamage(int damage)
    {
        if (health > 0 && damage > 0)
        {
            health -= damage;
        }
    }
    public void Heal(int amount)
    {
        if (health > 0 && amount > 0)
        {
            health -= amount;
        }
    }
    public void CollectCoins(int amount)
    {
        if (amount > 0)
        {
            coins += amount;
            Debug.Log("Earned coins: " + amount);
            Debug.Log("Total coins: " + coins);
        }
    }
    public void SpendCoins(int amount)
    {
        if (amount > 0)
        {
            coins -= amount;
        }
    }

}
