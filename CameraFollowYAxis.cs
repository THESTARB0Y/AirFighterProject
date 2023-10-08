using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowYAxis : MonoBehaviour
{
    public Transform target;   // The target spaceship to follow.
    public float yOffset = 2.0f; // The vertical offset from the spaceship.

    private void Update()
    {
        if (target != null)
        {
            // Get the current camera position.
            Vector3 currentPosition = transform.position;

            // Set the camera's Y-position to the spaceship's Y-position plus the offset.
            currentPosition.y = target.position.y + yOffset;

            // Apply the new camera position.
            transform.position = currentPosition;
        }
    }
}
