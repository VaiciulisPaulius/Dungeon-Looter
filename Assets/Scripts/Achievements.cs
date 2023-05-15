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
    }

}
