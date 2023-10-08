using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    private Camera mainCamera;
    private float cameraWidth;

    public float moveSpeed = 5f; // Adjust the speed as needed.

    private void Start()
    {
        mainCamera = Camera.main;
        cameraWidth = mainCamera.orthographicSize * mainCamera.aspect;
    }

    private void Update()
    {
        // Get input for movement.
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Calculate the movement direction and apply speed.
        Vector3 movement = new Vector3(moveX, moveY, 0) * moveSpeed * Time.deltaTime;

        // Update the spaceship's position.
        transform.Translate(movement);

        // Check if the spaceship is out of bounds on the right side.
        if (transform.position.x > cameraWidth)
        {
            // Teleport to the left side.
            Vector3 newPosition = new Vector3(-cameraWidth, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
        // Check if the spaceship is out of bounds on the left side.
        else if (transform.position.x < -cameraWidth)
        {
            // Teleport to the right side.
            Vector3 newPosition = new Vector3(cameraWidth, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
}