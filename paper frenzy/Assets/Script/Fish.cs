using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float Speed, maxY, minY, maxX, minX;
    public int size = 1;

    Vector2 poss;
    float currentXpos;

    void Start()
    {
        currentXpos = transform.position.x;
        poss = new Vector2(Random.Range(minX, maxY), Random.Range(minY, maxY));
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, poss, Speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, poss) < 0.5f)
        {
            poss = new Vector2(Random.Range(minX, maxY), Random.Range(minY, maxY));
        }

        if (transform.position.x > currentXpos)
        {
            transform.localScale = new Vector3(1, 1, 1);
            currentXpos = transform.position.x;
        }

        if (transform.position.x < currentXpos)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            currentXpos = transform.position.x;
        }
    }
}
