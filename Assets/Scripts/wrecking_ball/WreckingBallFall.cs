using UnityEngine;
using System.Collections;

public class WreckingBallFall : MonoBehaviour
{
    public float delayBeforeFall = 2f;

    AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        if (audioManager == null)
        {
            Debug.LogError("AudioManager not found in the scene.");
        }
    }

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(EnableGravityAfterDelay());
    }

    IEnumerator EnableGravityAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeFall);
        rb.isKinematic = false; // Jetzt fällt der Ball

        audioManager.PlaySFX(audioManager.wreckingBall, 0.8f);

    }
}
