using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : Collidable
{
    public float XTeleport = 0;
    public float YTeleport = 0;

    public GameObject Player;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            Debug.Log(transform.position.x + XTeleport);
            Player.transform.position = new Vector3((transform.position.x + XTeleport), (transform.position.y + YTeleport), 0);
            Debug.Log(transform.position.y);
        }
    }
}
