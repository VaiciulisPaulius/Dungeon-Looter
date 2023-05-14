using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] int moneyInside;
    [SerializeField] Animator animator;
    [SerializeField] GameObject item;

    private bool playChestAnimation;
    private bool playPickupLootAnimation;

    [SerializeField] GameObject highlighter;

    bool canPlayerOpenChest = false;
    bool canPlayerConfirmPickup = false;

    private void Update()
    {
        if(canPlayerOpenChest && Input.GetKeyDown(KeyCode.E))
        {
            playChestAnimation = true;
            animator.SetBool("PlayChestAnimation", playChestAnimation);

            canPlayerOpenChest = false;

            GetComponent<Lootbox>().InstantiateLoot();
            canPlayerConfirmPickup = true;
        }
        else if(canPlayerConfirmPickup && Input.GetKeyDown(KeyCode.E))
        {
            playPickupLootAnimation = true;
            GetComponent<Lootbox>().PickUpLoot(moneyInside);

            canPlayerConfirmPickup = false;
            highlighter.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && playChestAnimation == false)
        {
            canPlayerOpenChest = true;
            highlighter.SetActive(true);
        }
        else if (collision.tag == "Player" && playPickupLootAnimation == false)
        {
            canPlayerConfirmPickup = true;
            highlighter.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && playChestAnimation == false)
        {
            canPlayerOpenChest = false;
            highlighter.SetActive(false);
        }
        else if (collision.tag == "Player" && playPickupLootAnimation == false)
        {
            canPlayerConfirmPickup = false;
            highlighter.SetActive(false);
        }
    }
}
