using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreUI;
    public static int scoreCount;

    public Text scoreMultiplier;
    public static float multiplier = 1.0f;

    private float timer = 0f;
    private float checkInterval = 3f;

    private float lastCheckedHealth;
    private HealthSystem healthSystem;

    void Start()
    {
        if (ScoreManager.Instance != null)
        {
            scoreCount = ScoreManager.Instance.GetTotalScore();
        }

        healthSystem = FindObjectOfType<HealthSystem>();
        if (healthSystem != null)
        {
            lastCheckedHealth = healthSystem.currentHealth;
        }
    }

    void Update()
    {
        scoreUI.text = "Score: " + scoreCount;
        scoreMultiplier.text = "Multiplier: " + multiplier.ToString("F1") + "x";

        timer += Time.deltaTime;

        if (healthSystem != null && healthSystem.currentHealth < lastCheckedHealth)
        {
            multiplier = 1.0f;
        }

        if (timer >= checkInterval)
        {
            float charismaFactor = 0.05f;
            int charisma = CharismaManager.Instance != null ? CharismaManager.Instance.charisma : 0;
            multiplier += 0.1f * (1 + charisma * charismaFactor);

            multiplier = Mathf.Min(multiplier, 10.0f); // Optional max limit

            scoreCount += Mathf.RoundToInt(multiplier * 10);

            if (healthSystem != null)
                lastCheckedHealth = healthSystem.currentHealth;

            timer = 0f;
        }
    }

    public void AddPickupMultiplier()
    {
        multiplier += 1.0f;
        Debug.Log("Score Increment called");
    }

    public static int CurrentScore => scoreCount;

    private void OnDisable()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.AddScore(scoreCount);
        }
    }
}