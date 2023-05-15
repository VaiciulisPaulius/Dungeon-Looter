using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFunction : MonoBehaviour
{
    public Player player;

    void OnMouseDown()
    {
        Debug.Log("CLICKED");
        player.Heal(10);
       
    }
}
