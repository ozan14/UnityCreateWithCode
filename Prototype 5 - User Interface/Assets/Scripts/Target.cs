using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    private Rigidbody objectRb;

    public float weakestForce= 11f;
    public float strongestForce = 18f;
    public float weakestTorque = -10f;
    public float strongestTorque = 10f;
    private GameManager gameManager;
    public int liveChange;

    public int pointValue;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        objectRb = GetComponent<Rigidbody>();
        objectRb.AddForce(randomUpwardForce(), ForceMode.Impulse);
        objectRb.AddTorque(randomTorque(),randomTorque(),randomTorque(), ForceMode.Impulse);
        transform.position = randomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!gameManager.gameOverStatus)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, transform.rotation);
            gameManager.updateScore(pointValue);
            gameManager.updateLives(liveChange);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad") && gameManager.lives <1)
        {
            gameManager.gameOver();
        } else if(!gameObject.CompareTag("Bad") && gameManager.lives > 0)
        {
            
            gameManager.updateLives(-1);
        }


    }

    public Vector3 randomUpwardForce() 
    {
        return Vector3.up * Random.Range(weakestForce, strongestForce);
    }

    public float randomTorque()
    {
        return Random.Range(weakestTorque, strongestTorque);
    }

    public Vector3 randomSpawnPos()
    {
        return new Vector3(Random.Range(-4, 4), -3);
    }

    
}
