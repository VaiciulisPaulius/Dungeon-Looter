using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = Player.Instance;
    }

    void Update()
    {
        if (player.score >= 10 && !player.HasUnlockedAchievement("First chest looted!"))
        {
            player.UnlockAchievement("First chest looted!");
        }
        if(player.score >= 50 && !player.HasUnlockedAchievement("5 chests looted!"))
        {
            player.UnlockAchievement("5 chests looted!");
        }
        if (player.score >= 100 && !player.HasUnlockedAchievement("10 chests looted!"))
        {
            player.UnlockAchievement("10 chests looted!");
        }
        if (player.score >= 250 && !player.HasUnlockedAchievement("25 chests looted!"))
        {
            player.UnlockAchievement("25 chests looted!");
        }
        if (player.score >= 500 && !player.HasUnlockedAchievement("50 chests looted!"))
        {
            player.UnlockAchievement("50 chests looted!");
        }
        if (player.level >= 2 && !player.HasUnlockedAchievement("Reached level 2!"))
        {
            player.UnlockAchievement("Reached level 2!");
        }
        if (player.level >= 3 && !player.HasUnlockedAchievement("Reached level 3!"))
        {
            player.UnlockAchievement("Reached level 3!");
        }
        if (player.level >= 4 && !player.HasUnlockedAchievement("Reached level 4!"))
        {
            player.UnlockAchievement("Reached level 4!");
        }
        if (player.level >= 5 && !player.HasUnlockedAchievement("Reached level 5!"))
        {
            player.UnlockAchievement("Reached level 5!");
        }
    }

}
