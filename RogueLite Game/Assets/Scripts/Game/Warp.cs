using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : Collidable
{

    public GameObject Player;
    public float XTeleport = 0;
    public float YTeleport = 0;

    protected override void OnCollide(Collider2D coll)
    {

        Player = GameObject.FindGameObjectWithTag("Player");
        if (coll.name == "Player")
        {
            Player.transform.position = new Vector3((transform.position.x + XTeleport), (transform.position.y + YTeleport), 0);

        }
    }

}
