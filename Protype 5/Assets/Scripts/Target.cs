  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    public ParticleSystem explosionParticle; // makes an exposin effect
    public int pointValue;


    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>(); // Set rigidbody
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        //Throw object upward
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        //make object spin
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        
        //start object below the screen
        transform.position = RandomSpawnPos();
    }

    private void OnMouseDown() // makes objects dissapear from scene and from hierarchy
    {
        if(gameManager.isGameActive)
        {Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if(!gameObject.CompareTag("Bad")) // "bad" games objects won't affect game when fall
        {
            gameManager.GameOver();
        
        }
    }


    Vector3 RandomForce() // sends object up into game view
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos() // makes object spin.
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    
}
