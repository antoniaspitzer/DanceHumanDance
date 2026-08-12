using UnityEngine;

public class DeathFloorRespawn : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has fallen through the death floor.");

            CharacterController controller = player.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.enabled = false;
                player.transform.position = respawnPoint.position;
                controller.enabled = true;
                Debug.Log("Player respawned at the designated respawn point.");
            }
            else
            {
                Debug.LogWarning("No CharacterController found on player.");
            }
        }
    }

    private void Start()
{
    // Hide the mesh renderer but keep the collider
    MeshRenderer renderer = GetComponent<MeshRenderer>();
    if (renderer != null)
    {
        renderer.enabled = false;
    }
}
}
