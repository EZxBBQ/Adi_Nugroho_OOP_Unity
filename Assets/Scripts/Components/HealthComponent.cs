using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    public UnityEvent OnEnemyDeath = new UnityEvent();
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;

    void Start()
    {
        health = maxHealth;
    }

    public int getHealth()
    {
        return health;
    }

    public void Subtract(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            if (gameObject.CompareTag("Enemy"))
            {
                OnEnemyDeath.Invoke();
            }
            
            Destroy(gameObject);
        }
    }
}
