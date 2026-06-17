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

    private bool isShooting;
    public float fireRate = 5;
    private float nextTimeToFire;

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (isShooting && Time.time >= nextTimeToFire)
        {
            fireRate = Time.time + 1f / fireRate;
            shoot();
        }

    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isShooting = true;
        }
        else if (context.canceled)
        {
            isShooting = false;
        }
    }

    private void shoot()
    {
        spawnedBullets.Add(Instantiate(bulletPrefab, transform.position, Quaternion.identity));
    }

}
