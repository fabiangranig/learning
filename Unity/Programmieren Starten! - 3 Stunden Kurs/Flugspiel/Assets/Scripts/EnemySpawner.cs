using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Public variables
    public GameObject asteroidPrefab;

    //Private variables
    private float timer = 2;

    bool TimerFinished()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer = 2;

            return true;
        }
        else
        {
            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerFinished())
        {
            //Spawn Asteroid
            Vector3 spawnPosition = new Vector3(Random.Range(-29, 29), 18, 0);
            Instantiate(asteroidPrefab, spawnPosition, asteroidPrefab.transform.rotation);
        }
    }
}
