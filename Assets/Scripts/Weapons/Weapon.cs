using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] private float shootIntervalInSeconds;
    [SerializeField] private bool isPlayerWeapon;


    [Header("Bullets")]
    public Bullet bullet;
    [SerializeField] private Transform bulletSpawnPoint;
    private Vector3 bulletOffset = new Vector3(0, 0.6f, 0);


    [Header("Bullet Pool")]
    private IObjectPool<Bullet> objectPool;


    private readonly bool collectionCheck = false;
    private readonly int defaultCapacity = 20;
    private readonly int maxSize = 100;
    private float timer;

    public Transform parentTransform;

    void Awake() 
    {
        objectPool = new ObjectPool<Bullet>(createBullet, onGetFromPool, onReleaseToPool, onDestroyPooledObject, collectionCheck, defaultCapacity, maxSize);
        if (this.gameObject.tag == "Enemy")
        {
            bulletOffset = new Vector3(0, 0, 0);
        }
    }

    void FixedUpdate()
    {
        timer += bullet.bulletSpeed * Time.fixedDeltaTime;
        if (timer >= shootIntervalInSeconds)
        {
            timer = 0;
            Bullet bulletObject = objectPool.Get();

            if (bulletObject == null)
            {
                return;
            }

            bulletSpawnPoint.transform.position = this.transform.position;
            bulletObject.transform.position = bulletSpawnPoint.transform.position + bulletOffset;

            bulletObject.gameObject.SetActive(true);
            Rigidbody2D bullet_rb = bulletObject.GetComponent<Rigidbody2D>();

            if (isPlayerWeapon == true)
            {
                bullet_rb.velocity = bulletObject.transform.up * bulletObject.bulletSpeed;
            }
            else
            {
                bullet_rb.velocity = -bulletObject.transform.up * bulletObject.bulletSpeed;
            }
            

            bulletObject.Deactivate();
        }
        
    }

    private Bullet createBullet()
    {
        Bullet bulletInstance = Instantiate(bullet, parentTransform);
        bulletInstance.ObjectPool = objectPool;
        return bulletInstance;
    }

    private void onGetFromPool(Bullet pooledBullet)
    {
        pooledBullet.gameObject.SetActive(true);
    }

    private void onReleaseToPool(Bullet pooledBullet)
    {
        pooledBullet.gameObject.SetActive(false);
    }

    private void onDestroyPooledObject(Bullet pooledBullet)
    {
        Destroy(pooledBullet.gameObject);
    }
   
}
