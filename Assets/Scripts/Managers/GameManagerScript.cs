using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance; // Singleton instance

    public int score = 0; // Player's score
    public bool isGameActive = true; // Is the game running?

    void Awake()
    {
        // Ensure there is only one instance of GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    // Method to increase the score
    public void AddScore(int points)
    {
        if (isGameActive)
        {
            score += points;
            Debug.Log("Score: " + score);
        }
    }

    // Method to end the game
    public void EndGame()
    {
        isGameActive = false;
        Debug.Log("Game Over!");
        // Additional logic to handle game over, like displaying UI
    }
}