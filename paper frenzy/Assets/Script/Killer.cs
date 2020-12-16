using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    public float MaxPos, MinPos, Speed;
    void Start()
    {
        transform.position = new Vector3(transform.localPosition.x, Random.Range(MinPos, MaxPos), 0f);
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x - Speed * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);

        if (transform.position.x <= -30)
        {
            Destroy(gameObject);
        }
    }
}
