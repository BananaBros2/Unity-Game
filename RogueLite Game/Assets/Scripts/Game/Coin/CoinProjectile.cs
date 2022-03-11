using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinProjectile : MonoBehaviour
{
    private float rand;

    public float maxSpeed = 10f;

    private void Start()
    {
        rand = Random.Range(0.1f, 1f);
    }

    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(maxSpeed * Time.deltaTime, 0f, 0f);
        pos += transform.rotation * velocity;
        transform.position = pos;
        if (maxSpeed > 0)
        {
            maxSpeed = maxSpeed - rand;
        }
        else if (maxSpeed < 0)
        {
            maxSpeed = 0;
            transform.rotation = Quaternion.identity;
        }
    }
}

