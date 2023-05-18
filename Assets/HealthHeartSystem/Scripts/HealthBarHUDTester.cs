/*
 *  Author: ariel oliveira [o.arielg@gmail.com]
 */

using UnityEngine;

public class HealthBarHUDTester : MonoBehaviour
{
    public void AddHealth()
    {
        Player.Instance.AddHealth();
    }

    public void Heal(float health)
    {
        Player.Instance.Heal(health);
    }

    public void Hurt(float dmg)
    {
        Player.Instance.TakeDamage(dmg);
    }
}
