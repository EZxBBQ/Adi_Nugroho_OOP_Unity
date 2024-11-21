using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    [SerializeField] private bool isPlayerBullet;
    public float bulletSpeed = 20;
    public int damage = 10;
    private Rigidbody2D rb;

    private IObjectPool<Bullet> objectPool;

    public IObjectPool<Bullet> ObjectPool { set => objectPool = value; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Deactivate()
    {
        StartCoroutine(DeactivateRoutine());
    }

    IEnumerator DeactivateRoutine()
    {
        yield return new WaitForSeconds(2f);
        rb.velocity = Vector2.zero;

        if (objectPool != null)
        {
            objectPool.Release(this);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isPlayerBullet)
        {
            return;
        }
        rb.velocity = Vector2.zero;
        if (objectPool != null)
        {
            objectPool.Release(this);
        }
    }

    void OnBecameInvisible()
    {
        rb.velocity = Vector2.zero;
        if (objectPool != null)
        {
            objectPool.Release(this);
        }
    }
}