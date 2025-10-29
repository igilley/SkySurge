using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject fuelPrefab;
    public float spawnInterval = 1.2f;
    public float minY = -3.5f;
    public float maxY = 3.5f;

    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnRandom();
            timer = spawnInterval;
        }
    }

    void SpawnRandom()
    {
        float y = Random.Range(minY, maxY);
        Vector3 pos = new Vector3(transform.position.x, y, 0);
        int random = Random.Range(0, 100);

        if (random < 20) // 20% chance fuel
        {
            Instantiate(fuelPrefab, pos, Quaternion.identity);
        }
        else
        {
            Instantiate(obstaclePrefab, pos, Quaternion.identity);
        }
    }
}
