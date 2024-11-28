using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public Enemy spawnedEnemy;


    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 3;
    public int totalKill = 0;

    [SerializeField] private float spawnInterval = 3f;


    [Header("Spawned Enemies Counter")]
    public int spawnCount = 0;
    public int defaultSpawnCount;
    public int spawnCountMultiplier = 1;
    public int multiplierIncreaseCount = 1;


    public CombatManager combatManager;
    private PointUI pointUI;


    public bool isSpawning = false;
    private int spawnCountTemp;

    void Start()
    {
        spawnCount = defaultSpawnCount;
        spawnCountTemp = spawnCount;

        pointUI = GameObject.Find("UIDocument").GetComponent<PointUI>();
    }

    void FixedUpdate()
    {
        if (totalKill >= minimumKillsToIncreaseSpawnCount)
        {
            spawnCount += spawnCountMultiplier;
            spawnCountTemp = spawnCount; // save the current spawn count
            spawnCountMultiplier += multiplierIncreaseCount;
            totalKill = 0;
        }
    }

    // will be called if receive notofication from HealthComponent
    void OnEnemyDeath()
    {
        totalKill++;
        combatManager.DecreaseTotalEnemies();
        pointUI.AquirePoint(spawnedEnemy);
    }

    public void StartSpawning()
    {
        StartCoroutine(StartSpawningEnemies());
    }

    IEnumerator StartSpawningEnemies()
    {
        isSpawning = true;
        while (spawnCount > 0)
        {
            Enemy enemyInstance = Instantiate(spawnedEnemy, transform);
            HealthComponent healthComponent = enemyInstance.GetComponent<HealthComponent>();
            healthComponent.OnEnemyDeath.AddListener(OnEnemyDeath);
            spawnCount--;
            yield return new WaitForSeconds(spawnInterval);
        }
        spawnCount = spawnCountTemp; // reset the spawn count to the saved spawn count amount
    }
}
