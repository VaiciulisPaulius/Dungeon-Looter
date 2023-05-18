using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ClickFunction : MonoBehaviour
{
    public Player player;
    public GameObject ShopUI;
    public static bool isInShop = false;
    public PlayerMovement playerMovement;
   
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.B) && EndGame.isDead == false && PauseMenu.isPaused == false && Achievements.isAchievementsOpen == false)
        {
            if (!isInShop)
            {
                EnterShop();
            }
            else
            {
                ExitShop();
            }

        }

    }

    public void ExitShop()
    {
        ShopUI.SetActive(false);
        Time.timeScale = 1f;
        isInShop = false;
        playerMovement.EnablePlayerMovement();
    }

    public void EnterShop()
    {
        ShopUI.SetActive(true);
        Time.timeScale = 0f;
        isInShop = true;
        playerMovement.DisablePlayerMovement();
    }
}
