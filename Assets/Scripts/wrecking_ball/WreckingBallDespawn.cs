using UnityEngine;
using System.Collections;

public class WreckingBallDespawn : MonoBehaviour
{
    public float despawnDelay = 3f; // Sekunden bis zum Despawn nach Bodenkontakt
    private bool hasHitGround = false;

    AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        if (audioManager == null)
        {
            Debug.LogError("AudioManager not found in the scene.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Optional: Nur despawnen, wenn es wirklich der Boden ist
        if (!hasHitGround && collision.gameObject.CompareTag("Ground"))
        {
            hasHitGround = true;
            StartCoroutine(DespawnAfterDelay());

            audioManager.PlaySFX(audioManager.wreckingBallHit, 0.5f);
        }
    }

    IEnumerator DespawnAfterDelay()
    {
        yield return new WaitForSeconds(despawnDelay);
        Destroy(gameObject); // Entfernt den Wrecking Ball aus der Szene
    }
}
