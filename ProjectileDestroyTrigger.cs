using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroyTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering object has the name "Projectile(Clone)".
        if (other.gameObject.name == "Projectile(Clone)")
        {
            // Destroy the projectile clone.
            Destroy(other.gameObject);
        }
    }
}