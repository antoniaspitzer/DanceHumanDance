using UnityEngine;
using System.Collections;

public class ExplosiveBarrel : MonoBehaviour
{
    public float explosionRadius = 10f;
    public float explosionDamage = 40f;
    public GameObject explosionEffect;

    private bool hasExploded = false;

    AudioManager audioManager;

    public void Explode()
    {
        if (hasExploded) return;
        hasExploded = true;

        audioManager = FindObjectOfType<AudioManager>();


        // Explosionseffekt abspielen
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            
            // AudioManager finden und Explosion abspielen
            audioManager.PlaySFX(audioManager.explosion, 0.8f);
        }

        // Alle Objekte im Radius finden
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (var hit in hitColliders)
        {
            // Nur Spieler treffen
            if (hit.CompareTag("Player"))
            {
                HealthSystem health = hit.GetComponent<HealthSystem>();
                if (health != null)
                {
                    health.TakeDamage(explosionDamage);
                }
            }
        }

        // Fass zerstören
        Destroy(gameObject);
    }

    // Hier kommt jetzt der Trigger-Handler
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Explode();
            Destroy(gameObject, 4f); // zerstört es nach 2 Sekunden
        }
    }
}