using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{

    public GameObject worker;
    public Transform spawnPoint;

    public float timeBetweenSpawns;
    float nextSpawnTime;

    public int numberOfWorkerSpawns;

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
            Instantiate(worker, spawnPoint.position, Quaternion.identity);
            numberOfWorkerSpawns--;

            if(numberOfWorkerSpawns <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
