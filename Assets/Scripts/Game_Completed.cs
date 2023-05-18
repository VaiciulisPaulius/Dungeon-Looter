using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Completed : MonoBehaviour
{
    public Player player;
    public GameObject GameCompletedUI;

    void Start()
    {
        player = GameManagement.player;
    }

    void Update()
    {

        if (player.score == 100) //&& EndGame.isDead == false && ClickFunction.isInShop == false && Achievements.isAchievementsOpen == false && PauseMenu.isPaused == false)
        {
            GameCompletedUI.SetActive(true);
        }
    }
}
