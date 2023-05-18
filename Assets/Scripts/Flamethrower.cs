using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    private Animator anim;

    private bool isWorking;
    [SerializeField] private float cooldown;
    [SerializeField] private float cooldownTimer;
    [SerializeField] private float duration;
    [SerializeField] private float damage; // added variable for damage inflicted on player
    [SerializeField] private float delay; // added variable for damage inflicted on player

    [SerializeField] private Player player; // added reference to player object

    private float damageTimer; // added timer for damage intervals

    bool isWithinRange;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameManagement.player; // find player object in scene
        cooldownTimer += delay;
    }

    private void Update()
    {
        cooldownTimer -= Time.deltaTime; // fixed error - should be subtracting deltaTime

        if (cooldownTimer < 0)
        {
            isWorking = !isWorking;
            if(isWorking) cooldownTimer = duration;
            else cooldownTimer = cooldown;
        }

        anim.SetBool("isWorking", isWorking);

        if (isWorking && isWithinRange)
        {
            player.TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isWithinRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isWithinRange = false;
        }
    }
}
