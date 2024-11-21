using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargeting : Enemy
{
    [SerializeField] private float enemySpeed;

    private Player player;

    private float screenHeight;
    private float screenWidth;

    private HealthComponent healthComponent;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;
        healthComponent = GetComponent<HealthComponent>();

        screenHeight = 2 * Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);
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
        float spawnY = Random.Range(-screenHeight / 2, screenHeight / 2);

        Vector2 spawnCoordinates = new Vector2(spawnX, spawnY);
        this.transform.position = spawnCoordinates;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            healthComponent.OnEnemyDeath.Invoke();
            Destroy(this.gameObject);
        }
    }
}
