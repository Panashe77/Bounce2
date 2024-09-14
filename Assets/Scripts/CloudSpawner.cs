using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab; // Reference to the cloud prefab
    public float spawnInterval = 5f; // Time interval between spawns
    public float cloudSpacing = 3f; // Distance between each cloud
    public float spawnHeight = 5f; // Y position for spawning clouds
    public float minHeight = 4f; // Minimum height for clouds
    public float maxHeight = 6f; // Maximum height for clouds

    private float timer = 0f;
    private Vector3 spawnPosition;

    void Start()
    {
        // Adjust the initial spawn position to include the spacing
        spawnPosition = new Vector3(transform.position.x + cloudSpacing, spawnHeight, transform.position.z);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCloud();
            timer = 0f;
        }
    }

    void SpawnCloud()
    {
        GameObject newCloud = Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
        float randomHeight = Random.Range(minHeight, maxHeight);
        newCloud.transform.position = new Vector3(newCloud.transform.position.x, randomHeight, newCloud.transform.position.z);
        spawnPosition.x += cloudSpacing; // Move the spawn position for the next cloud
    }
}
