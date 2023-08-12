using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    private static int score = 0;
    private static int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(int value)
    {
        if (lives > 0)
        {
            score += value;
            Debug.Log("Score is " + score);
        } else
        {
            Debug.Log("Game Over!");
        }
    }

    public void updateLives(int value)
    {
        lives += value;
        if (lives > 0)
        {
            Debug.Log("You have " + lives + " lives!");
        } else if(lives<1)
        {
            Debug.Log("Game Over!");
        }
    }
}
