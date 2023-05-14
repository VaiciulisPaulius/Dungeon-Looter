using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HpPotion : MonoBehaviour, ICollectible
{
    public static event HandleHpPotionCollected OnHpPotionCollected;
    public delegate void HandleHpPotionCollected(ItemData item);
    public ItemData hpPotionData;
    public void Collect()
    {
        Debug.Log("Collected");
        Destroy(gameObject);
        OnHpPotionCollected?.Invoke(hpPotionData);
    }

    
}
