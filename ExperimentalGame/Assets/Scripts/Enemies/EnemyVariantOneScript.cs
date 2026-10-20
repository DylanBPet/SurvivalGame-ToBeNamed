using UnityEngine;

public class EnemyVariantOneScript : MonoBehaviour
{

    public int moveSpeed;
    public Vector2 playerPos;

    float aggressionRange = 15;

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(playerPos, transform.position);
        if (distanceToPlayer < aggressionRange)
        {
            Vector2 direction = playerPos - (Vector2)transform.position;
            transform.up = direction;

            transform.position += transform.up * moveSpeed * Time.deltaTime;
        }
        
    }
}
