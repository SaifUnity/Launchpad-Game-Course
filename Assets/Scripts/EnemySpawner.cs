using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Transform[] spawnPoints;

    public GameObject enemy;

    public float timeBetweenSpawns;
    float nextSpawnTime;

    public GameObject soundWhenEnemySpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + timeBetweenSpawns;
            Transform randomSpawnpoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(soundWhenEnemySpawn);
            Instantiate(enemy, randomSpawnpoint.position, Quaternion.identity);
        }
    }
}
