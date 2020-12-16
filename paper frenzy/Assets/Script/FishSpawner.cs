using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject[] fish;
    public float MaxY, MinY, MaxX, MinX, SpawnInterval = .5f;
    float SpawnRate;

    void Start()
    {
        SpawnRate = SpawnInterval;
    }

    void Update()
    {
        if (SpawnRate <= 0)
        {
            int index = Random.Range(0, fish.Length);
            Instantiate(fish[index], new Vector2(Random.Range(MinX, MaxX), Random.Range(MinY, MaxY)), Quaternion.identity);
            SpawnRate = SpawnInterval;
        }

        else
        {
            SpawnRate -= Time.deltaTime;
        }
    }
}
