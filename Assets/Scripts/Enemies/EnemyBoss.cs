using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{
    [SerializeField] private float enemySpeed;
    private Rigidbody2D rb;

    private float screenHeight;
    private float screenWidth;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenHeight = 2 * Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;

        SpawnEnemy();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float tolerance = 0.1f;
        if ((screenWidth / 2) - this.transform.position.x < tolerance)
        {
            rb.velocity = new Vector2(-enemySpeed, 0);
        }
        else if ((-screenWidth / 2) - this.transform.position.x > -tolerance)
        {
            rb.velocity = new Vector2(enemySpeed, 0);
        }
    }

    public override void SpawnEnemy()
    {
        int isSpawnRight = Random.Range(0,2);
        float spawnX;

        if (isSpawnRight == 1)
        {
            spawnX = screenWidth / 2;
        }
        else
        {
            spawnX = -screenWidth / 2;
        }
        float spawnY = Random.Range(0, screenHeight / 4);

        Vector2 spawnCoordinates = new Vector2(spawnX, spawnY);
        this.transform.position = spawnCoordinates;
            
    }
}
