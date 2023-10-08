using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;

    // Time delay between shots.
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    private void Update()
    {
        // Check if it's time to fire another projectile.
        if (Time.time >= nextFireTime)
        {
            FireProjectile();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void FireProjectile()
    {
        // Check if the projectilePrefab is not null before creating a new projectile.
        if (projectilePrefab != null && firePoint != null)
        {
            // Create a new projectile clone at the fire point's position and set the rotation to -180 degrees on the z-axis.
            GameObject newProjectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(0f, 0f, -180f));

            // Calculate the projectile's velocity.
            Vector3 direction = Vector3.down; // Shoot on the -y Axis.
            Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * projectileSpeed;
        }
    }
}