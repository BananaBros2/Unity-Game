using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCamera : Collidable
{

    public GameObject player;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            CameraGrid.instance.ChangeTarget(transform);
        }
    }

}

