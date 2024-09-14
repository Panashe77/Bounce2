using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab; // Reference to the pipe prefab
    public float spawnInterval = 2f; // Time interval between spawns
    public float pipeSpacing = 1.5f; // Distance between each pipe
    public float spawnHeight = 0f; // Y position for spawning pipes
    public float minHeight = 0.01f; // Minimum height scale for pipes
    public float maxHeight = 0.1f; // Maximum height scale for pipes

    private float timer = 0f;
    private Vector3 spawnPosition;

    void Start()
    {
        // Adjust the initial spawn position to include the spacing
        spawnPosition = new Vector3(transform.position.x + pipeSpacing, spawnHeight, transform.position.z);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    void SpawnPipe()
    {
        GameObject newPipe = Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
        float randomHeight = Random.Range(minHeight, maxHeight);
        newPipe.transform.localScale = new Vector3(newPipe.transform.localScale.x, randomHeight, newPipe.transform.localScale.z);
        spawnPosition.x += pipeSpacing; // Move the spawn position for the next pipe
    }
}
