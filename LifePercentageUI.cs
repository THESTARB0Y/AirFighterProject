using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePercentageUI : MonoBehaviour
{
    public Text lifePercentageText; // Reference to the UI Text element.

    private float lifePercentage; // The current life percentage.

    private void Start()
    {
        // Initialize the UI text with the initial life percentage.
        UpdateLifePercentage(100f); // Set it to 100% at the beginning (or your initial value).
    }

    // Call this method to update the displayed Life Percentage.
    public void UpdateLifePercentage(float percentage)
    {
        // Update the lifePercentage variable.
        lifePercentage = percentage;

        // Update the UI Text element to display the new value.
        lifePercentageText.text = "Life: " + lifePercentage.ToString("F0") + "%";
    }
}