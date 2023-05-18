using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Completed : MonoBehaviour
{
    private Player player;
    public GameObject GameCompletedUI;
    private PlayerMovement playerMovement;
    void Start()
    {
        player = GameManagement.player; 
        playerMovement = GameManagement.playerMovement;
    }

    void Update()
    {
        if (player.score >= 100 && EndGame.isDead == false && ClickFunction.isInShop == false && Achievements.isAchievementsOpen == false && PauseMenu.isPaused == false)
        {
            GameCompletedUI.SetActive(true);
            playerMovement.DisablePlayerMovement();
        }
    }
}
