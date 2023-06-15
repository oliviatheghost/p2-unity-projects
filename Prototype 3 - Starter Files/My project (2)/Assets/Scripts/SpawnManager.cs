using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    private Vector3 spawnPos = new Vector3(0, 0, 20);
    private float startDelay = 2;
    private float repeatRate = 3;
    public float spawnRangeX = 8.0f;
    public float spawnPosZ = 20f;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy" , startDelay, repeatRate ); 
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        {
          Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

          Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);  
        }
    }
}
