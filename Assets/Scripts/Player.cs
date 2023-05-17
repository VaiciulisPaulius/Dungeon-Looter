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
    public int[] expTable = { 0, 20, 30, 40, 50 };
    private ProgressBar progressBar;
    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;
    public ShopManager shop;

    // If reference error, drag the references from the materials folder, accordingly to the names.
    [SerializeField]
    Material flashMaterial;
    [SerializeField]
    Material flashHealMaterial;
    [SerializeField]
    Material defaultMaterial;
    [SerializeField]
    float flashDuration;

    float flashTimer;
    bool playFlashDamageAnimation;
    bool playFlashHealAnimation;
    SpriteRenderer playerSpriteRenderer;
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
    public float maxHealth;
    [SerializeField]
    private float maxTotalHealth;

    PlayerMovement playerMovementRef;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }

    bool canTakeDamage = true;
    [SerializeField]
    float damageCooldown;
    float timer;


    private void Start()
    {
        progressBar = FindObjectOfType<ProgressBar>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerMovementRef = GetComponent<PlayerMovement>();
        flashTimer = 0;
    }
    private void Update()
    {
        if (playFlashDamageAnimation) PlayFlashAnimation(flashMaterial);
        else if(playFlashHealAnimation) PlayFlashAnimation(flashHealMaterial);
        if (!canTakeDamage)
        {
            timer += Time.deltaTime;
            if(timer >= damageCooldown)
            {
                timer = 0;
                canTakeDamage = true;
            }
        }
    }
    public void Heal(float health)
    {
        this.health += health;

        playerMovementRef.SetPlayerSpeed(playerMovementRef.GetPlayerSpeed() * 0.5f);
        playFlashHealAnimation = true;

        ClampHealth();
    }
    private void PlayFlashAnimation(Material material)
    {
        if(flashTimer >= flashDuration)
        {
            playFlashDamageAnimation = false;
            playFlashHealAnimation = false;

            playerSpriteRenderer.material = defaultMaterial;
            flashTimer = 0;
            playerMovementRef.SetPlayerSpeedToDefault();
            return;
        }
        flashTimer += Time.deltaTime;
        playerSpriteRenderer.material = material;
    }
    public void TakeDamage(float dmg)
    {
        if(canTakeDamage)
        {
            health -= dmg;
            playerMovementRef.SetPlayerSpeed(playerMovementRef.GetPlayerSpeed() * 0.5f);

            playFlashDamageAnimation = true;
            if (health <= 0)
            {
                EndGame.isDead = true;
                health = 0;
                Debug.Log("Player took damage: " + dmg);
                OnPlayerDeath?.Invoke();
            }
            ClampHealth();
            canTakeDamage = false;
        }
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
            progressBar.BarValue = (float)exp / expTable[level] * 100f;
        }
    }

    public void CheckLevelUp()
    {
        if (level < 5 && exp >= expTable[level])
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {
        level++;
        exp = 0;
        progressBar.UpdateLevelText(level);
        AddHealth();
    }

}
