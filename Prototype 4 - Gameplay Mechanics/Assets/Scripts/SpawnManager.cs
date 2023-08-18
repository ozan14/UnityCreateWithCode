using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomLocation", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomLocation()
    {
        Instantiate(enemyPrefab, new Vector3(0,0,0), enemyPrefab.transform.rotation);
    }
}
