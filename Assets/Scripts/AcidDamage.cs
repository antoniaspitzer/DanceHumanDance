using UnityEngine;

public class AcidDamage : MonoBehaviour
{
    public float damagePerSecond = 50f;
    private float damageTimer = 0f;

    void OnTriggerEnter(Collider other)
    {
        HealthSystem player = other.GetComponent<HealthSystem>();
        if (player != null)
        {
            // Sofortiger Schaden beim ersten Kontakt
            player.TakeDamage(damagePerSecond * 2); //verdoppelt den Schaden beim ersten Kontakt
            damageTimer = 0f;
        }
    }

    void OnTriggerStay(Collider other)
    {
        HealthSystem player = other.GetComponent<HealthSystem>();
        if (player != null)
        {
            damageTimer += Time.deltaTime;

            if (damageTimer >= 1f)
            {
                player.TakeDamage(damagePerSecond);
                damageTimer = 0f;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        damageTimer = 0f;
    }
}