using UnityEngine;

public class EnemyVariantOneScript : MonoBehaviour
{

    public int moveSpeed;
    private Vector2 direction;
    public Vector2 playerPos;

    

    void Update()
    {
        direction = playerPos - (Vector2)transform.position;
        transform.up = direction;

        transform.position += transform.up * moveSpeed * Time.deltaTime;
    }
}
