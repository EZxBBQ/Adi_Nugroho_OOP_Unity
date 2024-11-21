using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawners;
    public float timer = 0;
    [SerializeField] private float waveInterval = 5f;
    public int waveNumber = 0;
    public int totalEnemies = 0;

    public bool isWaveStarted = false;

    void FixedUpdate()
    {
        if (isWaveStarted == false)
        {
            timer += Time.deltaTime;
        }

        if (timer >= waveInterval)
        {
            isWaveStarted = true;
            StartWave();
        }
    }

    public void StartWave()
    {
        timer = 0;
        waveNumber++;
        foreach (EnemySpawner enemySpawner in enemySpawners)
        {
            if (enemySpawner.spawnedEnemy.level <= waveNumber)
            {
                Debug.Log(enemySpawner.spawnedEnemy.name + " is spawning");
                totalEnemies += enemySpawner.spawnCount;
                enemySpawner.StartSpawning();
            }
        }
        
    }
    
    public void DecreaseTotalEnemies()
    {
        totalEnemies--;

        if (totalEnemies == 0)
        {
            isWaveStarted = false;
        }
    }

}
