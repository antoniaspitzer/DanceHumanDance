using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public HealthbarImage healthbarUI;

    private Coroutine regenRoutine;

    AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        if (audioManager == null)
        {
            Debug.LogError("AudioManager not found in the scene.");
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        audioManager.PlaySFX(audioManager.ouch, 0.8f);
        FindObjectOfType<DamageUI>()?.ShowDamageEffect();

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player is dead - Restarting Scene...");
        UnityEngine.SceneManagement.SceneManager.LoadScene("DeathScreen");
    }



    public void IncreaseMaxHealth(float amount)
    {
        maxHealth += amount;
        currentHealth = maxHealth; // Optional: volle Heilung bei Upgrade
        UpdateHealthUI();
        Debug.Log("Max Health increased to: " + maxHealth);
    }

    public void StartRegen(float ratePerSecond, float duration)
    {
        if (regenRoutine != null)
            StopCoroutine(regenRoutine);

        regenRoutine = StartCoroutine(RegenCoroutine(ratePerSecond, duration));
    }

    private IEnumerator RegenCoroutine(float rate, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            currentHealth += rate * Time.deltaTime;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            UpdateHealthUI();

            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    private void UpdateHealthUI()
    {
        if (healthbarUI != null)
        {
            healthbarUI.UpdateHealth(currentHealth / maxHealth);
        }
    }
}
