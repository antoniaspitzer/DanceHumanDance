using UnityEngine;
using StarterAssets;



public class ItemBase : MonoBehaviour
{
    [Tooltip("Rotate Degrees per Second")]
    public Vector3 rotationSpeed = new Vector3(0, 90, 0); // Degrees per second

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ThirdPersonController player = other.GetComponent<ThirdPersonController>();
            if (player != null)
            {
                OnCollect(player);
                CharismaManager.Instance?.AddCharisma(1);
                Destroy(gameObject);

            }
        }

       
    }

    public virtual void OnCollect(ThirdPersonController player)
    {

    }
}

