using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float carSpeed = 20;
    private float turnSpeed = 60;
    private float horizontalInput;
    private float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // These variables are either 1.0 or -1.0 depending on what key is pressed (0 if none are pressed)
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        // We'll make the vehicle move forward here
        transform.Translate(Vector3.forward * Time.deltaTime * carSpeed * forwardInput);
        transform.Rotate(Vector3.up,  Time.deltaTime * turnSpeed *  horizontalInput);
    }
}
