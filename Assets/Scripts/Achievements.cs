using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Achievements : MonoBehaviour
{
    private Player player;
    private PlayerMovement playerMovement;
    private HashSet<string> unlockedAchievements = new HashSet<string>();
    public GameObject popupUIPrefab;
    public Transform canvasTransform;
    private GameObject currentPopupUI;

    public TextMeshProUGUI unlockedAchievementsText;
    public TextMeshProUGUI lockedAchievementsText;
    public GameObject achievementPanel;
    public static bool isAchievementsOpen = false;

    public bool didPlayerBuyBoots;
    public bool didPlayerBuyPotion;

    private Dictionary<string, int> achievements = new Dictionary<string, int>()
    {
        { "First chest looted!", 10 },
        { "5 chests looted!", 50 },
        { "9 chests looted! 1 to go!", 90 },
        { "Reached level 2!", 2 },
        { "Reached level 3!", 3 },
        { "Bought boots from shop!", 1 },
        { "Bought HP pot from shop!", 1 }
    };

    private void Start()
    {
        player = Player.Instance;
        playerMovement = GameManagement.playerMovement;
        UpdateAchievementLists();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && EndGame.isDead == false && PauseMenu.isPaused == false && ClickFunction.isInShop == false)
        {
            if (!isAchievementsOpen)
            {
                EnterAchievements();
            }
            else
            {
                ExitAchievements();
            }
        }



        foreach (var achievement in achievements)
        {
            if (!unlockedAchievements.Contains(achievement.Key))
            {
                bool shouldUnlock = false;

                if (achievement.Key.Contains("chest") && player.score >= achievement.Value)
                {
                    shouldUnlock = true;
                }
                else if (achievement.Key.Contains("level") && player.level >= achievement.Value)
                {
                    shouldUnlock = true;
                }
                else if (achievement.Key.Contains("Bought boots") && didPlayerBuyBoots)
                {
                    shouldUnlock = true;
                }
                else if (achievement.Key.Contains("Bought HP pot") && didPlayerBuyPotion)
                {
                    shouldUnlock = true;
                }

                if (shouldUnlock)
                {
                    UnlockAchievement(achievement.Key);
                    unlockedAchievements.Add(achievement.Key);
                    UpdateAchievementLists();
                }
            }
        }
    }

    public bool HasUnlockedAchievement(string achievementName)
    {
        return unlockedAchievements.Contains(achievementName);
    }

    public void UnlockAchievement(string achievementName)
    {
        unlockedAchievements.Add(achievementName);
        ShowPopupUI("Achievement Unlocked: " + achievementName);
    }

    private void ShowPopupUI(string text)
    {
        if (currentPopupUI == null)
        {
            currentPopupUI = Instantiate(popupUIPrefab, canvasTransform);
        }

        currentPopupUI.GetComponent<PopupUI>().SetText(text);
        currentPopupUI.SetActive(true);
    }

    private void UpdateAchievementLists()
    {
        unlockedAchievementsText.text = "";
        lockedAchievementsText.text = "";

        foreach (var achievement in achievements)
        {
            if (unlockedAchievements.Contains(achievement.Key))
            {
                unlockedAchievementsText.text += achievement.Key + "\n";
            }
            else
            {
                lockedAchievementsText.text += achievement.Key + "\n";
            }
        }
    }

    public void ExitAchievements()
    {
        achievementPanel.SetActive(false);
        Time.timeScale = 1f;
        isAchievementsOpen = false;
        playerMovement.EnablePlayerMovement();
    }

    public void EnterAchievements()
    {
        achievementPanel.SetActive(true);
        Time.timeScale = 0f;
        isAchievementsOpen = true;
        playerMovement.DisablePlayerMovement();
    }
}
