using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool canSpawnDog = true;
    private float timer = 2f;
    private float interval = 2f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog and set canSpawnDog to false
        if (Input.GetKeyDown(KeyCode.Space) && canSpawnDog)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            canSpawnDog = false;
        }
        DogTimer(interval);
        
    }
    //if player recently spawned a dog and canSpawnDog is false, run this method
    void DogTimer(float delay)
    {
        if(timer > delay)
        {
            canSpawnDog = true;
            timer = 0f;
        } else if(canSpawnDog == false)
        {
            timer += Time.deltaTime;
        }
        
    }
}
