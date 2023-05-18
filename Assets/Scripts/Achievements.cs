using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    private Player player;
    private HashSet<string> unlockedAchievements = new HashSet<string>();
    public GameObject popupUIPrefab;
    public Transform canvasTransform;
    private GameObject currentPopupUI;

    private Dictionary<string, int> achievements = new Dictionary<string, int>()
    {
        { "First chest looted!", 10 },
        { "5 chests looted!", 50 },
        { "10 chests looted!", 100 },
        { "25 chests looted!", 250 },
        { "50 chests looted!", 500 },
        { "Reached level 2!", 2 },
        { "Reached level 3!", 3 },
        { "Reached level 4!", 4 },
        { "Reached level 5!", 5 }
    };

    private void Start()
    {
        player = Player.Instance;
    }

    private void Update()
    {
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

                if (shouldUnlock)
                {
                    UnlockAchievement(achievement.Key);
                    unlockedAchievements.Add(achievement.Key);
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
}
