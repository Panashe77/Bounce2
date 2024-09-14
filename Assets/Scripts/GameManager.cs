using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public StartTextController startTextController; // Reference to the StartTextController
    public TextMeshProUGUI pipeCounterText; // Reference to the counter TextMeshProUGUI component
    public GameObject player; // Reference to the player GameObject
    public Button startButton; // Reference to the start button
    public Button restartButton; // Reference to the restart button
    public GameObject groundPrefab; // Reference to the ground prefab
    private List<GameObject> groundInstances = new List<GameObject>(); // List to keep track of ground instances
    private int pipeCounter = 0;
    private bool gameStarted = false; // Flag to control player movement

    void Start()
    {
        // Ensure the game does not start automatically
        gameStarted = false;
        startButton.gameObject.SetActive(true); // Show the start button
        restartButton.gameObject.SetActive(false); // Hide the restart button
        InstantiateGround(); // Instantiate ground at the start
    }

    public void StartGame()
    {
        // Show the start text when the game starts
        startTextController.ShowStartText();
        // Additional logic to start the game
        Invoke("HideStartText", 3f); // Hide the text after 3 seconds
        gameStarted = true; // Allow player movement
        startButton.gameObject.SetActive(false); // Hide the start button
        restartButton.gameObject.SetActive(false); // Hide the restart button
        BackgroundMusicManager.Instance.PlayMusic(); // Start the background music
    }

    public void GameOver()
    {
        // Show the restart button when the game is over
        restartButton.gameObject.SetActive(true);
        gameStarted = false; // Prevent player movement
        BackgroundMusicManager.Instance.PauseMusic(); // Pause the background music
    }

    public void RestartGame()
    {
        // Show the start text when the game restarts
        startTextController.ShowStartText();
        // Additional logic to restart the game
        Invoke("HideStartText", 3f); // Hide the text after 3 seconds
        ResetPlayerState(); // Reset the player's state
        ResetPipeCounter(); // Reset the pipe counter
        ResetGround(); // Reset the ground
        gameStarted = false; // Prevent player movement until game starts again
        startButton.gameObject.SetActive(true); // Show the start button
        restartButton.gameObject.SetActive(false); // Hide the restart button
        BackgroundMusicManager.Instance.ResumeMusic(); // Resume the background music
    }

    void HideStartText()
    {
        startTextController.HideStartText();
    }

    // Call this method when a pipe is jumped
    public void PipeJumped()
    {
        IncrementPipeCounter();
    }

    // Method to increment the pipe counter
    private void IncrementPipeCounter()
    {
        pipeCounter++;
        UpdatePipeCounterText();
    }

    // Method to update the pipe counter text
    private void UpdatePipeCounterText()
    {
        pipeCounterText.text = "Pipes Jumped: " + pipeCounter;
    }

    // Method to reset the pipe counter
    private void ResetPipeCounter()
    {
        pipeCounter = 0;
        UpdatePipeCounterText();
    }

    // Method to reset the player's state
    private void ResetPlayerState()
    {
        player.transform.position = new Vector3(0, -3.5f, 0); // Reset position to ground level
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero; // Reset velocity
        player.GetComponent<Stamina>().currentStamina = player.GetComponent<Stamina>().maxStamina; // Reset stamina

        Debug.Log("Player state reset: Position = " + player.transform.position + ", Velocity = " + rb.velocity + ", Stamina = " + player.GetComponent<Stamina>().currentStamina);
    }

    // Method to instantiate ground prefabs
    private void InstantiateGround()
    {
        // Instantiate ground prefabs at the desired positions
        for (int i = 0; i < 5; i++)
        {
            Vector3 position = new Vector3(i * 10, -5, 0); // Adjust position as needed
            GameObject groundInstance = Instantiate(groundPrefab, position, Quaternion.identity);
            groundInstances.Add(groundInstance);
        }
    }

    // Method to reset ground prefabs
    private void ResetGround()
    {
        // Destroy existing ground instances
        foreach (GameObject ground in groundInstances)
        {
            Destroy(ground);
        }
        groundInstances.Clear();

        // Instantiate new ground prefabs
        InstantiateGround();
    }

    public bool IsGameStarted()
    {
        return gameStarted;
    }
}
