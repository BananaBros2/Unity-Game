using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGrid : Collidable
{

    public static CameraGrid instance;

    public float Speed;
    public Transform target;

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x+0.001f, target.position.y, -10), Speed * Time.deltaTime);
        }
    }

    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
    }
}