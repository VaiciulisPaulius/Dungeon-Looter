using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static event Action OnPlayerDeath;

    public int coins = 0;
    public int score = 0;
    public int level = 1;
    public int exp = 0;
    public int expToNextLevel = 20;
    private ProgressBar progressBar;
    private List<string> unlockedAchievements = new List<string>();
    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;
    public ShopManager shop;

    #region Sigleton
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<Player>();
            return instance;
        }
    }
    #endregion

    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float maxTotalHealth;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }


    private void Start()
    {
        progressBar = FindObjectOfType<ProgressBar>();
    }
    public void Heal(float health)
    {
        this.health += health;
        ClampHealth();
    }

    public void TakeDamage(float dmg)
    {

        health -= dmg;
        if (health <= 0)
        {
            EndGame.isDead = true;
            health = 0;
            Debug.Log("Player took damage: " + dmg);
            OnPlayerDeath?.Invoke();
        }
        ClampHealth();
    }

    public void AddHealth()
    {
        if (maxHealth < maxTotalHealth)
        {
            maxHealth += 1;
            health = maxHealth;

            if (onHealthChangedCallback != null)
                onHealthChangedCallback.Invoke();
        }
    }

    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }
    public void CollectCoins(int amount)
    {
        if (amount > 0)
        {
            coins += amount;
            Debug.Log("Earned coins: " + amount);
            Debug.Log("Total coins: " + coins);
            shop.CheckPurchaseable();
        }

    }
    public void SpendCoins(int amount)
    {
        if (amount > 0)
        {
            coins -= amount;
        }
    }

    public void CollectScore(int amount)
    {
        if (amount > 0)
        {
            score += amount;
            exp += amount;
            CheckLevelUp();
            progressBar.BarValue = (float)exp / expToNextLevel * 100f;
            Debug.Log("Earned score: " + amount);
            Debug.Log("Total score: " + score);
            Debug.Log("Total exp: " + exp);
        }
    }

    public void CheckLevelUp()
    {
        if (exp >= expToNextLevel)
        {
            LevelUp();
        }
    }


    public void LevelUp()
    {
        level++;
        exp = 0;
        expToNextLevel += 10;
        progressBar.UpdateLevelText(level);
        AddHealth();
        Debug.Log("Congratulations! You have reached level " + level + ".");

    }
        public bool HasUnlockedAchievement(string achievementName)
    {
        return unlockedAchievements.Contains(achievementName);
    }

    public void UnlockAchievement(string achievementName)
    {
        unlockedAchievements.Add(achievementName);
        Debug.Log("Achievement Unlocked: " + achievementName);
    }



}
