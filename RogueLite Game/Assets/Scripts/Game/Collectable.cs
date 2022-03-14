using System.Collections;       // Namespace references that the script can use
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable       // The Collectable class will use features from the Collidable class
{
    protected bool collected;       // Starts a new variable that keeps track if a object has already been collected or not

    protected override void OnCollide(Collider2D coll)      // Uses the OnCollide function from the Collidable script.
    {
        if (coll.name == "Player")       // Checks if the collided object was the player by using the name
        {
            OnCollect();        // Will call the OnCollect function which will likely be overrided
        }
    }

    protected virtual void OnCollect()      // A currently blank function
    {

    }
}
