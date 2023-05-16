using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour, ICollectible
{
    public static event HandleItemCollected OnItemCollected;
    public delegate void HandleItemCollected(Loot item);
    public Loot data;
    public void Collect(bool delete)
    {
        Debug.Log("Collected");
        if (delete) Destroy(gameObject);
        OnItemCollected?.Invoke(data);
    }

}
