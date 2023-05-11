using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootboxCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Lootbox>().InstantiateLoot(transform.position);
    }

}
