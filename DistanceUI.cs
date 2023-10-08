using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceUI : MonoBehaviour
{
    public Text distanceText; // Reference to the UI Text element.
    public Transform spaceShip; // Reference to the "SpaceShip" transform.

    private float initialYPosition; // The initial y-position of the "SpaceShip."
    private float maxDistance; // The maximum distance traveled.

    private void Start()
    {
        // Record the initial y-position of the "SpaceShip."
        initialYPosition = spaceShip.position.y;

        // Initialize the UI text with an initial distance value.
        maxDistance = 0f;
        UpdateDistanceText();
    }

    private void Update()
    {
        // Calculate the distance traveled in the y-axis.
        float currentYPosition = spaceShip.position.y;
        if (currentYPosition > initialYPosition)
        {
            maxDistance = Mathf.Max(maxDistance, currentYPosition - initialYPosition);
            UpdateDistanceText();
        }
    }

    // Call this method to update the displayed distance.
    private void UpdateDistanceText()
    {
        // Update the UI Text element to display the maximum distance value.
        distanceText.text = "Distance: " + maxDistance.ToString("F0");
    }
}