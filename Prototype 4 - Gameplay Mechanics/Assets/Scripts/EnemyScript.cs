using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 towardPlayer = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce( towardPlayer * speed);
    }
}
