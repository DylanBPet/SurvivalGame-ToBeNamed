using UnityEngine;

public class EnemyVariantOneScript : MonoBehaviour
{

    public int moveSpeed;
    public Transform playerPos;

    public float aggressionRange = 2;

    public TrackingEnemiesScript enemiesListScript;

    void Start()
    {
        enemiesListScript.spawnedEnemiesVOne.Add(gameObject);
    }

    void Update()
    {
        Vector2 directionToPlayer = playerPos.transform.position - transform.position;
        directionToPlayer = directionToPlayer.normalized;
        Debug.DrawLine(transform.position, directionToPlayer);

        float distanceToPlayer = Vector2.Distance(playerPos.transform.position, transform.position);

        if (distanceToPlayer < aggressionRange)
        {
            Vector2 direction = playerPos.transform.position - transform.position;
            transform.up = direction;

            transform.position += transform.up * moveSpeed * Time.deltaTime;
        }
        
    }
}
