using UnityEngine;
using TMPro;

public class StartTextController : MonoBehaviour
{
    public TextMeshProUGUI startText; // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI pipeCounterText; // Reference to the counter TextMeshProUGUI component
    private int pipeCounter = 0;

    void Start()
    {
        Debug.Log("StartTextController started");
        ShowStartText();
        UpdatePipeCounter(0); // Initialize the counter
    }

    public void ShowStartText()
    {
        startText.gameObject.SetActive(true);
    }

    public void HideStartText()
    {
        startText.gameObject.SetActive(false);
        Debug.Log("Text hidden");
    }

    public void UpdatePipeCounter(int count)
    {
        pipeCounter = count;
        pipeCounterText.text = "Pipes Jumped: " + pipeCounter;
    }

    // Call this method when the game starts
    public void OnGameStart()
    {
        HideStartText();
        UpdatePipeCounter(0); // Reset the counter when the game starts
    }

    // Call this method when the game restarts
    public void OnGameRestart()
    {
        HideStartText();
        UpdatePipeCounter(0); // Reset the counter when the game restarts
    }

    // Call this method to increment the counter
    public void IncrementPipeCounter()
    {
        UpdatePipeCounter(pipeCounter + 1);
    }
}
