using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{

    public TMPro.TextMeshProUGUI scoreText;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && scoreText != null)
        {
            scoreText.text = "Score: " + player.score;
        }
    }
}
