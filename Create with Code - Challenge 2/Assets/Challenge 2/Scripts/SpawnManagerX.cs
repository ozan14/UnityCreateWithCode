using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float lowestTime = 3.0f;
    private float highestTime = 5.0f;
    private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomBall();
        
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        int randomIndex = Random.Range(0, ballPrefabs.Length);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[randomIndex], spawnPos, ballPrefabs[randomIndex].transform.rotation);
        spawnTime = Random.Range(lowestTime, highestTime);
        Invoke("SpawnRandomBall", spawnTime);
        Debug.Log(spawnTime);
    }

    //this method turned out to be useless because InvokeRepeating just called it once and used that value over and over ...
    //meaning that the spawn interval would change from game to game but not between each interval it spawned the balls
    //interesting to learn
    /*
    private float spawnInterval(float lowestTime, float highestTime)
    {
        float result = Random.Range(lowestTime, highestTime);
        Debug.Log(result);
        return result;

    }
    */

}
