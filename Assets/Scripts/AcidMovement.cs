using UnityEngine;
using System.Collections;

public class AcidMovement : MonoBehaviour
{
    public float height = 1.5f;             // Maximale Anstiegshöhe
    public float cycleDuration = 15f;       // Dauer für eine Richtung (hoch oder runter)
    public float topPauseDuration = 1f;     // Kurze Pause oben
    public float bottomPauseDuration = 8f;  // Längere Pause unten

    private Vector3 startPos;
    private float timer = 0f;
    private bool isPaused = false;
    private bool goingUp = true;
    private float pauseTimer = 0f;

    AudioManager audioManager;

    private bool sfxPlayedThisCycle = false;

    void Start()
    {
        startPos = transform.position;

        audioManager = FindObjectOfType<AudioManager>();
        audioManager.PlayAcidSFX(audioManager.säure, 0.8f);
        sfxPlayedThisCycle = true;

    }

    void Update()
    {
        if (isPaused)
        {
            pauseTimer += Time.deltaTime;
            float currentPause = goingUp ? topPauseDuration : bottomPauseDuration;

            if (pauseTimer >= currentPause)
            {
                isPaused = false;
                pauseTimer = 0f;
                goingUp = !goingUp;
                timer = 0f;

                audioManager = FindObjectOfType<AudioManager>();
                audioManager.PlayAcidSFX(audioManager.säure, 0.8f);
                sfxPlayedThisCycle = true;
            }
            return;
        }

        if (!sfxPlayedThisCycle)
        {
            // Nicht hier nochmal PlaySFX aufrufen – nur Flag verwalten
            sfxPlayedThisCycle = true;
        }

        timer += Time.deltaTime;
        float t = timer / cycleDuration;

        // Sanfte Bewegung
        float eased = Mathf.SmoothStep(0, 1, Mathf.Sin(t * Mathf.PI * 0.5f));

        if (!goingUp)
            eased = 1 - eased;

        float newY = startPos.y + eased * height;
        transform.position = new Vector3(startPos.x, newY, startPos.z);

        if (t >= 1f)
        {
            isPaused = true;
            sfxPlayedThisCycle = false; // Reset fürs nächste Mal
            audioManager = FindObjectOfType<AudioManager>();
            audioManager.StopAcidSFX(); // Nur Säure Sound stoppen
        }
    }
}