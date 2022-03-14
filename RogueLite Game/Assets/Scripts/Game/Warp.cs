using System.Collections;       // Namespace references that the script can use
using System.Collections.Generic;
using UnityEngine;

public class Warp : Collidable      // The Warp class will use features from the Collidable class
{
    public GameObject player;       // Starts a variable that will be used to track the player
    public float xTeleport = 0;         // Sets a variable for the X amount the player will be teleported and can be tweaked in the inspector
    public float yTeleport = 0;         // Sets a variable for the Y amount the player will be teleported and can be tweaked in the inspector

    protected override void OnCollide(Collider2D coll)      // Uses the Collidable script's OnCollide function for detecting collisions
    {
        player = GameObject.FindGameObjectWithTag("Player");        // Sets the 'player' variable as the game object with the 'Player' tag
        if (coll.name == "Player")      // If the object collided with the player, then go down this route
        {
            // Transforms the player game object by adding the set variables to the player's current position
            player.transform.position = new Vector3((transform.position.x + xTeleport), (transform.position.y + yTeleport), 0);
        }
    }
}
