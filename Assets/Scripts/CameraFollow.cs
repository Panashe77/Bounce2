using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset;   // Offset value to maintain the desired distance

    void Start()
    {
        // Initialize the offset based on the initial positions
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Update the camera's position based on the player's position and the offset
        transform.position = player.position + offset;
    }
}

