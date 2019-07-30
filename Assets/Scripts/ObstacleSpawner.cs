using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //public GameObject obstacle;

    public static ObstacleSpawner instance;

    public GameObject[] obstacles;

    public bool gameOver = false;

    public float minSpawnTime, maxSpawnTime;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        float waitTime = 1f;

        yield return new WaitForSeconds(waitTime);

        while (!gameOver)
        {
           

            SpawnOpstacle();

            waitTime = Random.Range(minSpawnTime, maxSpawnTime);

            yield return new WaitForSeconds(waitTime);


        }


    }

    void SpawnOpstacle()
    {
        int random = Random.Range(0, obstacles.Length);

        Instantiate(obstacles[random], transform.position, Quaternion.identity);
    }

}
