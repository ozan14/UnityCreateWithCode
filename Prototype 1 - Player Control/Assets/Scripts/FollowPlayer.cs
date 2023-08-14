using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -7);
    private Vector3 driverPOVOffset = new Vector3(0, (float) 2.2, 1);
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        followFromAbove();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetKeyDown("f"))
        {
            i += 1;
        }
        if(i%2==0)
        {
            followFromAbove();

        } else
        {
            followInDriver();
        }
        
    }

    void followFromAbove()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.position = player.transform.position + offset;
        

    }

    void followInDriver()
    {
        transform.position = player.transform.position + driverPOVOffset;
        transform.rotation = player.transform.rotation;
    }
}
