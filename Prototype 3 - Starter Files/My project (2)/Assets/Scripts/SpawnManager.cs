using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy" , startDelay, repeatRate ); 
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
          if (!playerControllerScript.gameOver)
        {
          Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);  
        }
    }
}
