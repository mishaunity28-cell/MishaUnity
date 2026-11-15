using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public float spawnRange = 9;
    private int enemiesCount;
    private int waveNumber = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(waveNumber);
        SpawnPowerup();
    }

    // Update is called once per frame
    void Update()
    {
        enemiesCount = FindObjectsOfType<Enemy>().Length;
        if (enemiesCount <= 0)
        {
            waveNumber++;
            SpawnEnemy(waveNumber);
            SpawnPowerup();
        }
    }

    public Vector3 GetSpawnPosition()
    {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPosition = new Vector3(spawnPositionX, 0, spawnPositionZ);
        return randomPosition;
    }

    private void SpawnEnemy(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab,GetSpawnPosition(),Quaternion.identity);
        }
        
    }

    private void SpawnPowerup()
    {
        Instantiate(powerupPrefab,GetSpawnPosition(),Quaternion.identity);
    }
}
    
