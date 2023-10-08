using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    public Material redMaterial; // Assign the RedMaterial you created in step 1.
    private bool isRed = false;
    private float redDuration = 0.5f; // Adjust the duration as needed.

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    private void Update()
    {
        if (isRed)
        {
            // If the EnemySpaceShip is currently red, count down the duration.
            redDuration -= Time.deltaTime;

            if (redDuration <= 0f)
            {
                // Revert to the original material after the specified duration.
                RevertToOriginalMaterial();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the entering object has the tag "Projectile."
        if (collision.gameObject.name == "Projectile(Clone)")
        {
            // Destroy the projectile clone with a specified delay.
            Destroy(collision.gameObject);

            // Change the color to red (or the assigned material).
            spriteRenderer.material = redMaterial;

            // Start the countdown.
            redDuration = 0.09f; // Adjust the duration as needed.
            isRed = true;
        }
    }

    private void RevertToOriginalMaterial()
    {
        // Change the color back to the original material.
        spriteRenderer.material = originalMaterial;
        isRed = false;
    }
}

