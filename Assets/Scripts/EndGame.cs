using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject gameOverMenu;
    public static bool isDead;

    public void Start()
    {
        isDead = false;
    }
    
    public void enableGameOverMenu()
    {
        gameOverMenu.SetActive(true);

    }

    private void OnEnable()
    {
        Player.OnPlayerDeath += enableGameOverMenu;

    }
    private void OnDisable()
    {
        Player.OnPlayerDeath -= enableGameOverMenu;

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
