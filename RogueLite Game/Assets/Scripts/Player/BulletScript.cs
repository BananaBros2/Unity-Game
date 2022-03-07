using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float maxSpeed = 10f;

    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(maxSpeed * Time.deltaTime, 0f, 0f);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }
}
