//SpikeTrap.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    private Animator anim;

    private bool isWorking;
    [SerializeField] private float cooldown;
    [SerializeField] private float cooldownTimer;
    [SerializeField] private float damage; // added variable for damage inflicted on player

    [SerializeField] private Player player; // added reference to player object

    private float damageTimer; // added timer for damage intervals

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>(); // find player object in scene
    }

    private void Update()
    {
        cooldownTimer -= Time.deltaTime; // fixed error - should be subtracting deltaTime

        if (cooldownTimer < 0)
        {
            isWorking = !isWorking;
            cooldownTimer = cooldown;
        }

        anim.SetBool("isWorking", isWorking);

        if (isWorking && Vector3.Distance(transform.position, player.transform.position) < 1.0f)
        {
            if (damageTimer <= 0) // check if damage timer has expired
            {
                player.TakeDamage(damage);
                damageTimer = 5.0f; // reset damage timer
            }
            else
            {
                damageTimer -= Time.deltaTime; // decrement damage timer
            }
        }
        else if (!isWorking) // if spike trap is inactive, reset damage timer
        {
            damageTimer = 0;
        }
    }
}
