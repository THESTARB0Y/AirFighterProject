using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class SimpleShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform[] firePoints;
    public float projectileSpeed = 10f;
    public float fireRate = 0.5f;

    private float nextFireTime = 0f;
    private List<GameObject> projectileClones = new List<GameObject>(); // Store projectile clones.

    private void Update()
    {
        if (projectilePrefab != null)
        {
            if (Time.time >= nextFireTime)
            {
                foreach (Transform firePoint in firePoints)
                {
                    FireProjectile(firePoint);
                }
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    private void FireProjectile(Transform firePoint)
    {
        if (projectilePrefab != null)
        {
            GameObject newProjectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            projectileClones.Add(newProjectile); // Add the clone to the list.

            Vector3 direction = firePoint.up;
            Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * projectileSpeed;
        }
    }

    // Call this method to destroy all projectile clones.
    public void DestroyProjectileClones()
    {
        foreach (GameObject projectileClone in projectileClones)
        {
            Destroy(projectileClone);
        }
        projectileClones.Clear(); // Clear the list.
    }
}