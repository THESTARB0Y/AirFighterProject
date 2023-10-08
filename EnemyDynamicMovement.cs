using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDynamicMovement : MonoBehaviour
{
    private Transform spaceShip;
    private Vector3 previousSpaceShipPosition;

    private void Start()
    {
        spaceShip = GameObject.Find("SpaceShip").transform; // Find the SpaceShip object.
        previousSpaceShipPosition = spaceShip.position;
    }

    private void Update()
    {
        // Calculate the change in SpaceShip position since the last frame.
        Vector3 deltaPosition = spaceShip.position - previousSpaceShipPosition;

        // Calculate the speed of the EnemySpaceShip based on SpaceShip's vertical movement.
        float enemySpeed = deltaPosition.y / Time.deltaTime;

        // Move the EnemySpaceShip vertically in the direction of the SpaceShip at the calculated speed.
        Vector3 direction = Vector3.up; // Move in the y-axis direction.
        transform.position += direction * enemySpeed * Time.deltaTime;

        // Rotate the EnemySpaceShip to face the SpaceShip (if needed).
        // You can use Quaternion.LookRotation or other methods to achieve this.

        // Update the previous SpaceShip position for the next frame.
        previousSpaceShipPosition = spaceShip.position;
    }
}