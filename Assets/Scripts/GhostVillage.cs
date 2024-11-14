using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostVillage : MonoBehaviour
{

    public GameObject objectToSpawn;

    public GameObject buildParticles;

    public GameObject soundWhenSpawn1;
    public GameObject soundWhenSpawn2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        transform.position = mousePos;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            Instantiate(soundWhenSpawn1, transform.position, Quaternion.identity);
            Instantiate(soundWhenSpawn2, transform.position, Quaternion.identity);
            Instantiate(buildParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
