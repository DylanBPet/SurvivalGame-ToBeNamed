using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemyScript : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Vector2 playerPos;
    private Vector2 enemySpawnPos;

    public List<GameObject> spawnedEnemies;

    void Update()
    {
        playerPos = transform.position;

        for (int i = 0; i < spawnedEnemies.Count; i++)
        {
           EnemyVariantOneScript enemyScript = spawnedEnemies[i].GetComponent<EnemyVariantOneScript>();
            enemyScript.playerPos = playerPos;
        }
    }

    public void SpawnEnemy()
    {
        GetRandomSpawn();
        spawnedEnemies.Add(Instantiate(enemyPrefab, enemySpawnPos, Quaternion.identity));
        
    }

    private void GetRandomSpawn()
    {
        enemySpawnPos = playerPos + (Random.insideUnitCircle.normalized * Random.Range(15, 30));
    }
}
