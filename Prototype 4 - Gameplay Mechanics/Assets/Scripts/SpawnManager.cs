using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9f;
    private int waveSize = 1;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveSize);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyScript>().Length;
        if(enemyCount == 0)
        {
            waveSize++;
            SpawnPowerup();
            SpawnEnemyWave(waveSize);
        }
    }

    void SpawnEnemyWave(int waveSize)
    {
        for(int i = 0; i < waveSize; i++)
        {
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        Vector3 randomPos = GenerateSpawnPosition();
        Instantiate(enemyPrefab, randomPos, enemyPrefab.transform.rotation);
    }

    void SpawnPowerup()
    {
        Vector3 randomPos = GenerateSpawnPosition();
        Instantiate(powerupPrefab, randomPos, powerupPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
