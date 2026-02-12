using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private GameObject powerup;

    [SerializeField] private int enemyCount;
    [SerializeField] private int waveNumber = 1;

    private GameObject[] enemyInScene;

    private float spawnRangeX = 9.0f;
    private float spawnRangeZ = 9.0f;
    

    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();

    }

    void Update()
    {
        
        enemyInScene = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemyInScene.Length;


        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }
    }

    private void SpawnPowerup()
    {
        Instantiate(powerup, GenerateSpawnPosition(), powerup.transform.rotation);

    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int randomEnemyIndex = Random.Range(0, enemyPrefab.Length);

            Instantiate(enemyPrefab[randomEnemyIndex], GenerateSpawnPosition(), enemyPrefab[randomEnemyIndex].transform.rotation);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosZ = Random.Range(-spawnRangeZ, spawnRangeZ);

        Vector3 randomSpawnPos = new Vector3(spawnPosZ, 0, spawnPosZ);

        return randomSpawnPos;
    }    
}
