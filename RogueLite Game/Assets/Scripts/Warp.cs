using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : Collidable
{
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            //Come back later
        }
    }
}
