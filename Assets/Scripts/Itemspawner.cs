using UnityEngine;



public class ItemSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject[] itemPrefabs;  // Assign different item prefabs in the inspector
    public float spawnInterval = 3f;

    [Header("Spawn Area (Centered on Spawner)")]
    public Vector2 areaSize = new Vector2(10f, 10f);  // Width and depth

    private void Start()
    {
        InvokeRepeating(nameof(SpawnItem), 0f, spawnInterval);
    }

    void SpawnItem()
    {
        if (itemPrefabs.Length == 0) return;

        Vector3 spawnPosition = GetRandomPositionInArea();
        int index = Random.Range(0, itemPrefabs.Length);

        Instantiate(itemPrefabs[index], spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomPositionInArea()
    {
        float x = Random.Range(-areaSize.x / 2, areaSize.x / 2);
        float z = Random.Range(-areaSize.y / 2, areaSize.y / 2);
        Vector3 offset = new Vector3(x, 0, z);
        return transform.position + offset;
    }

    private void OnDrawGizmosSelected()
    {
        // Draw the spawn area in the editor for reference
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + Vector3.up * 0.5f, new Vector3(areaSize.x, 1, areaSize.y));
    }
}

