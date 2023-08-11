using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float spawnRangeX = 20f;
    public float spawnPositionZ = 20f;

    private float firstSpawn = 0f;
    private float timeBetweenSpawns = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //spawns a random animal in a random location every timeBetweenSpawns seconds
        InvokeRepeating("SpawnAnimal", firstSpawn, timeBetweenSpawns);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAnimal()
    {
        int randomAnimal = Random.Range(0, animalPrefabs.Length);
        Vector3 randomSpawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPositionZ);
        Instantiate(animalPrefabs[randomAnimal], randomSpawnPos, animalPrefabs[randomAnimal].transform.rotation);
    }
}
