using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingBulletScript : MonoBehaviour
{
    public GameObject bulletPrefab;

    private Vector2 mousePos;
    private Vector2 direction;

    public List<GameObject> spawnedBullets;

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            spawnedBullets.Add(Instantiate(bulletPrefab, transform.position, Quaternion.identity));
        }
    }


}
