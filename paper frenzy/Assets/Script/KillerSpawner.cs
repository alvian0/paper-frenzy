using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerSpawner : MonoBehaviour
{
    public GameObject Killer;
    public float SpawnInterval = 1;

    float SpawnRate;

    void Start()
    {
        SpawnRate = SpawnInterval;
    }

    void Update()
    {
        if (SpawnRate <= 0)
        {
            Instantiate(Killer, transform.position, Quaternion.identity);
            SpawnRate = SpawnInterval;
        }

        else
        {
            SpawnRate -= Time.deltaTime;
        }
    }
}
