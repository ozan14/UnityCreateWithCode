using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 40f;
    private float lowerBound = -10f;
    public PointManager pointManager;
    // Start is called before the first frame update
    void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //destroys animals that get out of frame and removes from your score (only works if they spawn from the top and get past the player to the bottom)
        //didnt add functionality for when the animals step out of bounds on the x axis, should be relatively simple to implement though if you wish
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            pointManager.updateLives(-1);
            Destroy(gameObject);
            
        }
    }
}
