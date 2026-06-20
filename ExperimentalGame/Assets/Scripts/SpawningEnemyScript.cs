using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemyScript : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Vector2 playerPos;
    private Vector2 enemySpawnPos;

    public List<GameObject> spawnedEnemiesOne;

    //the math to spawn more enemies the longer the game goes
    public float initialSpawnDelay = 1.5f; //how long it takes initially in seconds to spawn an enemy
    public float minSpawnDelay = 0.2f; //how long it will take to spawn enemy when max difficulty is reached
    public float timeToMaxDifficulty = 120f; //how long it takes to reach max difficulty

    private float spawnTimer = 1.5f; //the time between spawning enemy

    public int enemiesToSpawn = 4; //how many enemies to spawn at a time
    void Update()
    {
        //time counts up since the game started up to the max difficulty
        //Clamp01 keeps the number between 0 and 1.0 so at max difficulty it will be a max of 1 (or 100 percent)
        float difficultyPercent = Mathf.Clamp01(Time.time / timeToMaxDifficulty);

        //a math function that creates a value percentage between two numbers
        // in this case it would be lerping between the initial spawn, the min spawn. with the difficultyPercent being the PERCENTAGE of how far it is
        float currentSpawnDelay = Mathf.Lerp(initialSpawnDelay, minSpawnDelay, difficultyPercent);

        //spawn timer counting up
        spawnTimer += Time.deltaTime;

        //if the spawn timer counts to or above the current spawn delay (changes based on difficulty percentage)
        if (spawnTimer > currentSpawnDelay)
        {
            //spawn enemy
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                SpawnEnemy();
            }
            //reset timer
            spawnTimer = 0;
        }

        playerPos = transform.position;

        for (int i = 0; i < spawnedEnemiesOne.Count; i++)
        {
           EnemyVariantOneScript enemyScript = spawnedEnemiesOne[i].GetComponent<EnemyVariantOneScript>();
            enemyScript.playerPos = playerPos;
        }
    }

    public void SpawnEnemy()
    {
        GetRandomSpawn();
        spawnedEnemiesOne.Add(Instantiate(enemyPrefab, enemySpawnPos, Quaternion.identity));
        
    }

    private void GetRandomSpawn()
    {
        enemySpawnPos = playerPos + (Random.insideUnitCircle.normalized * Random.Range(15, 30));
    }
}
