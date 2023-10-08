using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject backgroundPrefab; // The prefab for generating new background segments.
    public GameObject asteroidPrefab;   // The prefab for generating asteroids.
    public Transform spaceship;         // Reference to the spaceship.
    public float yOffset = 0f;          // The vertical offset for regenerating the background on the Y-axis.
    public float asteroidSpawnInterval = 10f; // Interval for spawning asteroids (in seconds).

    private Transform[] backgroundSegments;
    private float segmentHeight;
    private float timeSinceLastAsteroidSpawn = 0f;

    private void Start()
    {
        // Get the height of the background segment.
        segmentHeight = backgroundPrefab.GetComponent<SpriteRenderer>().bounds.size.y;

        // Create an array to store background segments.
        backgroundSegments = new Transform[3]; // Adjust this based on your needs.

        // Instantiate and position the initial background segments, and spawn asteroids for each one.
        for (int i = 0; i < backgroundSegments.Length; i++)
        {
            backgroundSegments[i] = Instantiate(backgroundPrefab, new Vector3(0, i * segmentHeight, 0), Quaternion.identity).transform;
            SpawnAsteroid(backgroundSegments[i]);
        }
    }

    private void Update()
    {
        // Check if the spaceship is getting close to the top edge of the current background segment.
        if (spaceship.position.y > backgroundSegments[backgroundSegments.Length - 1].position.y - segmentHeight)
        {
            // Move the topmost segment downward to create a new segment.
            backgroundSegments[0].position += Vector3.up * (backgroundSegments.Length * segmentHeight + yOffset);
            Transform temp = backgroundSegments[0];
            for (int i = 0; i < backgroundSegments.Length - 1; i++)
            {
                backgroundSegments[i] = backgroundSegments[i + 1];
            }
            backgroundSegments[backgroundSegments.Length - 1] = temp;

            // Spawn asteroids for the new background segment.
            SpawnAsteroid(backgroundSegments[backgroundSegments.Length - 1]);
        }
    }

    private void SpawnAsteroid(Transform backgroundSegment)
    {
        // Determine a random X position within the screen boundaries.
        float randomX = Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x, Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x);

        // Create an asteroid at the random position within the specified background segment.
        Instantiate(asteroidPrefab, new Vector3(randomX, backgroundSegment.position.y + 10f, 0), Quaternion.identity);
    }
}