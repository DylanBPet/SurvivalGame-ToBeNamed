using UnityEngine;
using UnityEngine.UI;

public class BulletandEnemyCheckScript : MonoBehaviour
{
    public ShootingBulletScript bulletScript;
    public SpawningEnemyScript spawningEnemyScript;

   

    void Update()
    {
        if (bulletScript.spawnedBullets != null && spawningEnemyScript.spawnedEnemiesOne != null)
        {
            for (int i = 0; i < bulletScript.spawnedBullets.Count; i++)
            {
                Transform bulletTransform = bulletScript.spawnedBullets[i].GetComponent<Transform>();

                for (int j = 0; j < spawningEnemyScript.spawnedEnemiesOne.Count; j++)
                {
                    SpriteRenderer enemySr = spawningEnemyScript.spawnedEnemiesOne[j].GetComponent<SpriteRenderer>();

                    if (enemySr.bounds.Contains(bulletTransform.transform.position))
                    {
                        EnemyTakeDamage(spawningEnemyScript.spawnedEnemiesOne[j], bulletScript.spawnedBullets[i]);
                    }

                }
            }
        }
    }

    public void EnemyTakeDamage(GameObject enemy, GameObject bullet)
    {
        //delete and remove bullet from list
        bulletScript.spawnedBullets.Remove(bullet);
        Destroy(bullet);

        //make the enemy take damage, if the bar is 0 or below, delete enemy and remove from list
        Slider enemyHealthBar = enemy.GetComponentInChildren<Slider>();
        enemyHealthBar.value -= 20;

        if (enemyHealthBar.value <= 0)
        {
            spawningEnemyScript.spawnedEnemiesOne.Remove(enemy);
            Destroy(enemy);
        }
        
    }
}
