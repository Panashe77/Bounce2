using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltSpawner : MonoBehaviour
{
    public GameObject boltPrefab; // Reference to the cloud prefab
    public float spawnInterval = 5f; // Time interval between spawns
    public float boltSpacing = 3f; // Distance between each cloud
    public float spawnHeight = 5f; // Y position for spawning clouds
    public float minHeight = 4f; // Minimum height for clouds
    public float maxHeight = 6f; // Maximum height for clouds

    private float timer = 0f;
    private Vector3 spawnPosition;

    void Start()
    {
        // Adjust the initial spawn position to include the spacing
        spawnPosition = new Vector3(transform.position.x + boltSpacing, spawnHeight, transform.position.z);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnBolt();
            timer = 0f;
        }
    }

    void SpawnBolt()
    {
        GameObject newBolt = Instantiate(boltPrefab, spawnPosition, Quaternion.identity);
        float randomHeight = Random.Range(minHeight, maxHeight);
        newBolt.transform.position = new Vector3(newBolt.transform.position.x, randomHeight, newBolt.transform.position.z);
        spawnPosition.x += boltSpacing; // Move the spawn position for the next bolt
    }
}
