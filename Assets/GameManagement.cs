using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public static GameObject playerObj { get; private set; }
    public static Player player { get; private set; }
    public static PlayerMovement playerMovement { get; private set; }
    void Awake()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<Player>();
        playerMovement = playerObj.GetComponent<PlayerMovement>();
    }
}
