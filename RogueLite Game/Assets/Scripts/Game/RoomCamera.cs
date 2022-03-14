using System.Collections;       // Namespace references that the script can use
using System.Collections.Generic;
using UnityEngine;

public class RoomCamera : Collidable        // The RoomCamera class will use features from the Collidable class
{
    public GameObject player;       // Finds and sets the player game object to a variable

    protected override void OnCollide(Collider2D coll)      // Uses the OnCollide function from the Collidable script
    {
        if (coll.CompareTag("Player"))      // Checks to see if the collided object has the 'Player' tag
        {
            CameraGrid.instance.ChangeTarget(transform);        // Uses the CameraGrid script to change what room the camera scrolls to
        }
    }

}

