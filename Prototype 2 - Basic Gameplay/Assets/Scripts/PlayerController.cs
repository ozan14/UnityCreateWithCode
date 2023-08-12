using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int horizontalInput;
    public int verticalInput;
    public float speed = 10f;
    public float xRange = 10f;
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //keeps player in bounds (with the range being from -xRange to +xRange)
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        //cast int because I want the player to move smoothly, stopping when button is let go,
        //moving at max speed when button is pressed in either direction
        horizontalInput = (int)Input.GetAxis("Horizontal");
        verticalInput = (int)Input.GetAxis("Vertical");
        transform.Translate(speed * horizontalInput * Time.deltaTime, 0, speed * verticalInput * Time.deltaTime);


        if(Input.GetKeyDown(KeyCode.Space)) {
            //spawns a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        
    }
}
