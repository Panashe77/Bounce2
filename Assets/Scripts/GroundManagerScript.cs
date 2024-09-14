using UnityEngine;
using System.Collections.Generic;

public class GroundManagerScript : MonoBehaviour
{
    public GameObject groundPrefab;
    public int numberOfGrounds = 5;
    public float groundLength = 10f;
    private List<GameObject> grounds = new List<GameObject>();
    private Transform playerTransform;
    public float groundYPosition = -6.5f; // Adjust this value as needed

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (playerTransform == null)
        {
            Debug.LogError("Player not found! Make sure the player GameObject has the tag 'Player'.");
        }

        for (int i = 0; i < numberOfGrounds; i++)
        {
            GameObject ground = Instantiate(groundPrefab, new Vector3(i * groundLength, groundYPosition, 0), Quaternion.identity);
            grounds.Add(ground);
        }

        if (grounds.Count == 0)
        {
            Debug.LogError("Grounds list is empty! Make sure ground prefabs are being instantiated correctly.");
        }
    }

    void Update()
    {
        if (playerTransform != null && grounds.Count > 0)
        {
            if (playerTransform.position.x > grounds[0].transform.position.x + groundLength)
            {
                GameObject tempGround = grounds[0];
                grounds.RemoveAt(0);
                tempGround.transform.position = new Vector3(grounds[grounds.Count - 1].transform.position.x + groundLength, groundYPosition, 0);
                grounds.Add(tempGround);
            }
        }
        else
        {
            Debug.LogError("PlayerTransform or Grounds list is not initialized properly.");
        }
    }
}
