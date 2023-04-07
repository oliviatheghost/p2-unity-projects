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
       SpawnEnemyWave(waveNumber);
       Instantiate(powerupPrefab, GenerareSpawnPosition(), powerupPrefab.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)

        {
            waveNumber++; 
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerareSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }



    // spawn a bunch of enemies each wave
    void SpawnEnemyWave(int enemiesToSpawn)
    { for (int i = 0; i < enemiesToSpawn; i++)
        {
        Instantiate(enemyPrefab, GenerareSpawnPosition(), enemyPrefab.transform.rotation);
        //Create new enemy gameObject
        }
    }


    private Vector3 GenerareSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
