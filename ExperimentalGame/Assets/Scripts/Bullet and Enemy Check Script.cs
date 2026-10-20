using UnityEngine;
using UnityEngine.UI;

public class BulletandEnemyCheckScript : MonoBehaviour
{
    public ShootingBulletScript bulletScript;
    public TrackingEnemiesScript enemyListScript;
    public ControllingXPandLvlupScript xpScript;

    void Update()
    {
        if (bulletScript.spawnedBullets != null && enemyListScript.spawnedEnemiesVOne != null)
        {
            for (int i = 0; i < bulletScript.spawnedBullets.Count; i++)
            {
                Transform bulletTransform = bulletScript.spawnedBullets[i].GetComponent<Transform>();

                //check for enemy variant one
                for (int j = 0; j < enemyListScript.spawnedEnemiesVOne.Count; j++)
                {
                    SpriteRenderer enemySr = enemyListScript.spawnedEnemiesVOne[j].GetComponent<SpriteRenderer>();

                    if (enemySr.bounds.Contains(bulletTransform.transform.position))
                    {
                        EnemyTakeDamage(enemyListScript.spawnedEnemiesVOne[j],bulletScript.spawnedBullets[i]);
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
        Slider healthBar = enemy.GetComponentInChildren<Slider>();
        healthBar.value -= 20;

        if (healthBar.value <= 0)
        {
            Vector2 pipSpawnPoint = enemy.transform.position;
            xpScript.SpawnXpPip(pipSpawnPoint);

            enemyListScript.spawnedEnemiesVOne.Remove(enemy);
            Destroy(enemy);

            //enemyListScript.enemyHealthBarList.Remove(enemyHealthBar);
            //Destroy(enemyHealthBar);
        }
        
    }
}
