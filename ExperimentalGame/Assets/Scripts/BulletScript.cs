using UnityEngine;
using UnityEngine.InputSystem;

public class BulletScript : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector2 direction;

    public int moveSpeed;

    void Start()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = mousePos - (Vector2)transform.position;
        transform.up = direction;
    }

    void Update()
    {
        transform.position += transform.up * moveSpeed * Time.deltaTime;
    }
}
