using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : Collidable
{

    public GameObject player;
    public float xTeleport = 0;
    public float yTeleport = 0;

    protected override void OnCollide(Collider2D coll)
    {

        player = GameObject.FindGameObjectWithTag("Player");
        if (coll.name == "Player")
        {
            player.transform.position = new Vector3((transform.position.x + xTeleport), (transform.position.y + yTeleport), 0);

        }
    }

}
