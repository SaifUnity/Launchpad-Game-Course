using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyed : MonoBehaviour
{

    public GameObject objectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("InstantiateAndDestroy", 5f);
    }

    // Update is called once per frame
    void InstantiateAndDestroy()
    {
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
