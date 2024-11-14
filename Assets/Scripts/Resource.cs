using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{

    public string resourceType;

    public int resourceAmount;

    public GameObject destroyedResource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (resourceAmount <= 0)
        {
            Instantiate(destroyedResource, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
