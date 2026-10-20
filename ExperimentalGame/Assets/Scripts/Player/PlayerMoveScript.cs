using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveScript : MonoBehaviour
{
    public float speed;
    public Vector2 movement;

    void Update()
    {
        transform.position += (Vector3)movement * speed * Time.deltaTime; 
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}
