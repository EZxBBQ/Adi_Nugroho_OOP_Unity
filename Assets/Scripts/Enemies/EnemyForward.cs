using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForward : Enemy
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

    void FixedUpdate() 
    {
        float tolerance = 0.1f;
        if ((screenHeight / 2) - this.transform.position.y < tolerance)
        {
            rb.velocity = new Vector2(0, -enemySpeed);
        }
        else if ((-screenHeight / 2) - this.transform.position.y > -tolerance)
        {
            rb.velocity = new Vector2(0, enemySpeed);
        }
    }

    public override void SpawnEnemy()
    {
        int isSpawnAbove = Random.Range(0,2);
        float spawnY;

        if (isSpawnAbove == 1)
        {
            spawnY = screenHeight / 2;
        }
        else
        {
            spawnY = -screenHeight / 2;
        }
        float spawnX = Random.Range(-screenWidth / 4, screenWidth / 4);

        Vector2 spawnCoordinates = new Vector2(spawnX, spawnY);
        this.transform.position = spawnCoordinates;
            
    }
}
