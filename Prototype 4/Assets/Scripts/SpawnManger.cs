using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
       SpawnEnemyWave(waveNumber);// number of enemy spaw waves
       Instantiate(powerupPrefab, GenerareSpawnPosition(), powerupPrefab.transform.rotation);//power up swpans in random position

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)

        {
            waveNumber++; 
            SpawnEnemyWave(waveNumber);// add 1 enemy each wave
            Instantiate(powerupPrefab, GenerareSpawnPosition(), powerupPrefab.transform.rotation);//enemy spawns in different positions
        }
    }



    // spawn a bunch of enemies each wave
    void SpawnEnemyWave(int enemiesToSpawn)
    { for (int i = 0; i < enemiesToSpawn; i++) // spawn a new enemy each wave
        {
        Instantiate(enemyPrefab, GenerareSpawnPosition(), enemyPrefab.transform.rotation);
        //Create new enemy gameObject
        }
    }


    private Vector3 GenerareSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange); //enemy spawns in random ranges in x range
        float spawnPosZ = Random.Range(-spawnRange, spawnRange); // enemt spawns in random ranges in z range

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos; // resent in the same position as start
    }
}
