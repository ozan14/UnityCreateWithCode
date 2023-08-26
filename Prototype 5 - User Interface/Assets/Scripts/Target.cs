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
    // Start is called before the first frame update
    void Start()
    {
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
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
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
