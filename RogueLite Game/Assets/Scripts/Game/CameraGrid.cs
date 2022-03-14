using System.Collections;       // Namespace references that the script can use
using System.Collections.Generic;
using UnityEngine;

public class CameraGrid : Collidable        // The CameraGrid class will use features from the Collidable class
{

    public static CameraGrid instance;      // a self referential variable which will be used by the RoomCamera script

    public float scrollSpeed;       // A variable which can be changed to alter the scrolling speed of the camera
    public Transform target;        //

    protected void Start()        // Start is called before the first frame update
    {
        instance = this;        // Sets the 'instance' variable to this object
    }

    protected void Update()       // Update is called once per frame
    {
        if (target != null)         // Checks if target was set to anything
        {
            // Takes the current position and moves this object towards the target room, the scrollSpeed (maxDistanceDelta) determins how far it moves each time
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x+0.001f, target.position.y, -10), scrollSpeed * Time.deltaTime);
        }
    }

    public void ChangeTarget(Transform newTarget)       // A function that takes the transform values of the active user and sets it as the new target 
    {
        target = newTarget;         // Is used by the RoomCamera script to determine the co-ordinates of the room to go to
    }
}

