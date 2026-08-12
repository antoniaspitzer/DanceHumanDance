using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float lifetime = 10f;
    public float damage = 20f;

    void Start()
    {
        Destroy(gameObject, lifetime); // Sicherheit: zerstören nach Zeit
    }

    private void OnCollisionEnter(Collision collision)
    {
        HealthSystem health = collision.collider.GetComponentInParent<HealthSystem>();
        if (health != null)
        {
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
