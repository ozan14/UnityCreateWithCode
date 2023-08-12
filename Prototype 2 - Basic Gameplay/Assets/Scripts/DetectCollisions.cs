using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public PointManager pointManager;
    
    // Start is called before the first frame update
    void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pointManager.updateLives(-1);
            Destroy(gameObject);
        } else if (other.CompareTag("Food"))
        {
            pointManager.updateScore(1);
            Destroy(gameObject);
            Destroy(other.gameObject);
            
        }

        
    }
}
