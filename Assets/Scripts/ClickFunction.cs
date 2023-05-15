using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ClickFunction : MonoBehaviour
{
    public Player player;
   



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.Heal(1);
            
        }

        
    }
}
