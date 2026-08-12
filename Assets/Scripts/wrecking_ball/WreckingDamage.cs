using UnityEngine;
using System.Collections;

public class WreckingDamage : MonoBehaviour
{
    public float damageAmount = 100f;
    public float damageCooldown = 1f; // Zeit zwischen Treffern
    private bool canDamage = true;

    void OnTriggerEnter(Collider other)
    {
        if (!canDamage) return;

        HealthSystem player = other.GetComponent<HealthSystem>();
        if (player != null)
        {
            player.TakeDamage(damageAmount);
            StartCoroutine(ResetDamageCooldown());
        }
    }

    IEnumerator ResetDamageCooldown()
    {
        canDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canDamage = true;
    }
}
