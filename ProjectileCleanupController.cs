using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCleanupController : MonoBehaviour
{
    private SimpleShooting simpleShooting;

    private void Start()
    {
        // Find the SimpleShooting script in the scene.
        simpleShooting = FindObjectOfType<SimpleShooting>();

        if (simpleShooting == null)
        {
            Debug.LogError("SimpleShooting script not found in the scene.");
        }
    }

    private void Update()
    {
        // For example, you can destroy all projectile clones when a certain condition is met.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DestroyAllProjectiles();
        }
    }

    // Call this method to destroy all projectile clones.
    private void DestroyAllProjectiles()
    {
        if (simpleShooting != null)
        {
            simpleShooting.DestroyProjectileClones();
        }
    }
}
