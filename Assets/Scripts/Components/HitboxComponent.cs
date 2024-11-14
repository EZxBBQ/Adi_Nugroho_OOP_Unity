using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    [SerializeField] private HealthComponent health;
    [SerializeField] private InvincibilityComponent invincibility;
    // Start is called before the first frame update
    public void Damage(Bullet bullet)
    {
        if (health != null && invincibility.isInvincible == false)
        {
            health.Subtract(bullet.damage);
        }
    }

    public void Damage(int damageAmount)
    {
        if (health != null && invincibility.isInvincible == false)
        {
            health.Subtract(damageAmount);
        }
    }

}
