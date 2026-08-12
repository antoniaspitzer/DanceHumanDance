using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float startTime = 60f;

    public TextMeshProUGUI finalScoreText;

    private float timeRemaining;
    private bool isRunning = true;

    void Start()
    {
        timeRemaining = startTime;

        if (finalScoreText != null)
            finalScoreText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isRunning)
            return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            isRunning = false;

            TimerEnded();
        }

        timerText.text = FormatTime(timeRemaining);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void TimerEnded()
    {
        Debug.Log("Timer is finished!");

        int score = Score.CurrentScore;

        if (finalScoreText != null)
        {
            finalScoreText.gameObject.SetActive(true);
            finalScoreText.text = "Your Score: " + score;
        }

        StartCoroutine(ShowScoreAndLoadScene());
    }

    private IEnumerator ShowScoreAndLoadScene()
    {
        yield return new WaitForSeconds(5f);

        int randomValue = Random.Range(1, 3);

        string currentScene = SceneManager.GetActiveScene().name;

        // 👉 Prüfe auf bestimmte Szene
        if (currentScene == "secondStage")
        {
            SceneManager.LoadScene("Endscene");
            yield break; // Beendet die Coroutine nach dem Wechsel
        }

        switch (randomValue)
        {
            case 1:
                SceneManager.LoadScene("Comic1");
                break;
            case 2:
                SceneManager.LoadScene("Comic2");
                break;
            default:
                SceneManager.LoadScene("Comic3");
                break;
        }
    }
}