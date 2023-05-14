using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootbox : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<Loot> lootList = new List<Loot>();

    GameObject lootGameObject;
    SpriteRenderer lootGameObjectSprite;

    bool playLootAnimation;
    bool playPickupLootAnimation;

    [SerializeField] float floatAmount;
    [SerializeField] [Range(0f, 1000f)] float speed;

    float alpha = 0;

    private void Update()
    {
        if(playLootAnimation && lootGameObject != null)
        {
            float step = speed * Time.deltaTime;


            alpha += step / floatAmount;

            lootGameObject.transform.localPosition = Vector3.MoveTowards(lootGameObject.transform.localPosition, new Vector3(0, floatAmount, -0.1f), step);
            lootGameObjectSprite.color = new Color(1, 1, 1, alpha);

            if (Vector2.Distance(lootGameObject.transform.localPosition, new Vector3(0, floatAmount, -0.1f)) < 0.1f)
            {
                playLootAnimation = false;
            }
        }
        else if(playPickupLootAnimation && lootGameObject != null)
        {
            float step = speed * Time.deltaTime;
            alpha -= (step / floatAmount) * 2;
            if (alpha < 0)
            {
                Destroy(lootGameObject);
                playPickupLootAnimation = false;
            }
            lootGameObjectSprite.color = new Color(1, 1, 1, alpha);
        }
    }

    Loot GetDroppedItem()
    {
        List<Loot> guaranteedItems = new List<Loot>();
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if (item.dropChance >= 100)
            {
                guaranteedItems.Add(item);
            }
            else
            {
                possibleItems.Add(item);
            }
        }

        if (guaranteedItems.Count > 0)
        {
            Loot droppedItem = guaranteedItems[Random.Range(0, guaranteedItems.Count)];
            return droppedItem;
        }
        else if (possibleItems.Count > 0)
        {
            Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        return null;
    }


    public void InstantiateLoot()
    {
        Loot droppedItem = GetDroppedItem();
        if (droppedItem != null)
        {
            lootGameObject = Instantiate(droppedItemPrefab, transform.position, Quaternion.identity, gameObject.transform);
            lootGameObjectSprite = lootGameObject.GetComponent<SpriteRenderer>();
            lootGameObjectSprite.sprite = droppedItem.lootSprite;

            lootGameObjectSprite.color = new Color(1, 1, 1, 0);

            playLootAnimation = true;
        }
    }
    public void PickUpLoot(int moneyAmount)
    {
        if (lootGameObject == null) return;

        Loot droppedItem = GetDroppedItem();
        if (droppedItem != null && droppedItem.isCoin)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CollectCoins(moneyAmount);
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().CollectScore(10);

        playPickupLootAnimation = true;
    }
}