using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
      enemyRb = GetComponent<Rigidbody>();
      player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized; // makes enemy follow player

        enemyRb.AddForce(lookDirection * speed); // enemy's speed

        if (transform.position.y < -10) // destroy enemy after position reaches below (0, -10) 
        {
           Destroy(gameObject); // after enemy is hit off of the island & reaches -10 = y, it will destory
        }
    }
}
