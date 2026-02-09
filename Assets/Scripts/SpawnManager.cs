using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    private float spawnRangeX = 9.0f;
    private float spawnRangeZ = 9.0f;

    void Start()
    {        
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    void Update()
    {
        
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosZ = Random.Range(-spawnRangeZ, spawnRangeZ);

        Vector3 randomSpawnPos = new Vector3(spawnPosZ, 0, spawnPosZ);

        return randomSpawnPos;
    }
}
