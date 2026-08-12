using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private LinkedList<int> scoreHistory; // LinkedList to store the scores

    void Awake()
    {
        // Ensure only one instance of ScoreManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object across scenes
            scoreHistory = new LinkedList<int>();
        }
        else
        {
            Destroy(gameObject); // Destroy if another instance exists
        }
    }

    // Add a score to the history
    public void AddScore(int score)
    {
        scoreHistory.AddLast(score);
    }

    // Get the total score so far (sum of all stored scores)
    public int GetTotalScore()
    {
        int totalScore = 0;
        foreach (var score in scoreHistory)
        {
            totalScore += score;
        }
        return totalScore;
    }

    // Reset the score history (if needed)
    public void ResetScores()
    {
        scoreHistory.Clear();
    }
}