using UnityEngine;
using UnityEngine.UI;

public class BulletandEnemyCheckScript : MonoBehaviour
{
    public ShootingBulletScript bulletScript;
    public SpawningEnemyScript spawningEnemyScript;
    public ControllingXPandLvlupScript xpScript;

    void Update()
    {
        if (bulletScript.spawnedBullets != null && spawningEnemyScript.spawnedEnemiesOne != null)
        {
            for (int i = 0; i < bulletScript.spawnedBullets.Count; i++)
            {
                Transform bulletTransform = bulletScript.spawnedBullets[i].GetComponent<Transform>();

                //check for enemy variant one
                for (int j = 0; j < spawningEnemyScript.spawnedEnemiesOne.Count; j++)
                {
                    SpriteRenderer enemySr = spawningEnemyScript.spawnedEnemiesOne[j].GetComponent<SpriteRenderer>();

                    if (enemySr.bounds.Contains(bulletTransform.transform.position))
                    {
                        EnemyTakeDamage(spawningEnemyScript.spawnedEnemiesOne[j], spawningEnemyScript.enemyHealthBarList[j],bulletScript.spawnedBullets[i]);
                    }

                }
            }
        }
    }

    public void EnemyTakeDamage(GameObject enemy, GameObject enemyHealthBar, GameObject bullet)
    {
        //delete and remove bullet from list
        bulletScript.spawnedBullets.Remove(bullet);
        Destroy(bullet);

        //make the enemy take damage, if the bar is 0 or below, delete enemy and remove from list
        Slider healthBar = enemyHealthBar.GetComponentInChildren<Slider>();
        healthBar.value -= 20;

        if (healthBar.value <= 0)
        {
            Vector2 pipSpawnPoint = enemy.transform.position;
            xpScript.SpawnXpPip(pipSpawnPoint);

            spawningEnemyScript.spawnedEnemiesOne.Remove(enemy);
            Destroy(enemy);
            spawningEnemyScript.enemyHealthBarList.Remove(enemyHealthBar);
            Destroy(enemyHealthBar);
        }
        
    }
}
