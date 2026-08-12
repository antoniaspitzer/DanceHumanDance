using UnityEngine;

public class CannonShooter : MonoBehaviour
{
    public GameObject projectilePrefab;       // Kugel-Prefab mit Rigidbody
    public Transform firePoint;               // Position & Richtung der Kanone
    public float shootForce = 10f;            // Anfangsgeschwindigkeit
    public float shootInterval = 1.5f;        // Sekunden zwischen Schüssen
    public float angleOffset = 30f;           // Abweichung in Grad (links/rechts)

    private float timer;

    AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        if (audioManager == null)
        {
            Debug.LogError("AudioManager not found in the scene.");
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootInterval)
        {
            ShootRandomDirection();
            timer = 0f;
        }
    }

    void ShootRandomDirection()
{
    if (projectilePrefab == null || firePoint == null) return;

    // Zufälliger Winkel zwischen -angleOffset und +angleOffset
    float randomAngle = Random.Range(-angleOffset, angleOffset);

    // Berechne neue Richtung basierend auf dem zufälligen Winkel
    Vector3 shootDir = Quaternion.Euler(0, randomAngle, 0) * firePoint.forward;

    GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

    audioManager.PlaySFX(audioManager.kanonen, 0.1f);

    Rigidbody rb = projectile.GetComponent<Rigidbody>();
    if (rb != null)
    {
        rb.linearVelocity = shootDir.normalized * shootForce; // Korrekte Eigenschaft ist "velocity"
    }
}
}
