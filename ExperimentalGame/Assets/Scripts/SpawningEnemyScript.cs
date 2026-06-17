using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemyScript : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Vector2 playerPos;
    private Vector2 EnemySpawnPos;

    public List<GameObject> spawnedEnemies;

    void Update()
    {
        playerPos = transform.position;
    }

    public void SpawnEnemy()
    {
        spawnedEnemies.Add(Instantiate(enemyPrefab, playerPos, Quaternion.identity));
    }
}
