using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    public GameObject barrelPrefab;
    public Vector3 spawnAreaMin; // z. B. (-40, 1, -40)
    public Vector3 spawnAreaMax; // z. B. (40, 1, 40)
    public float spawnInterval = 10f;
    public int barrelsPerSpawn = 3;  // Anzahl der Fässer pro Spawn

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            Debug.Log("SpawnBarrel wird aufgerufen");
            SpawnBarrel();
            timer = 0f;
        }
    }

    void SpawnBarrel()
    {
        for (int i = 0; i < barrelsPerSpawn; i++)
        {
            float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float y = spawnAreaMin.y;
            float z = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
            Vector3 spawnPos = new Vector3(x, y, z);

            Debug.Log($"Spawning barrel at {spawnPos}");
            Instantiate(barrelPrefab, spawnPos, Quaternion.identity);
        }
    }
}
