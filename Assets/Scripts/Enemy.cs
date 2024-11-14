using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float minX, maxX, minY, maxY;

    Vector3 currentTarget;

    public GameObject Remains;

    public GameObject soundWhenEnemyDies;

    public int gameOverIndex4;

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = GetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, currentTarget) > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }
        else
        {
            currentTarget = GetRandomPosition();
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        return randomPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Altar")
        {
            SceneManager.LoadScene(gameOverIndex4);
        }

        if (collision.tag == "Spikes")
        {
            Destroy(collision.gameObject);
            Instantiate(Remains, transform.position, Quaternion.identity);
            Instantiate(soundWhenEnemyDies, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }

}
