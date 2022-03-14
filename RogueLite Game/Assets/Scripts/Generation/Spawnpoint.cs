using System.Collections;       // Namespace references that the script can use
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour         // The Spawnpoint class will use features from the MonoBehaviour class
{
    public int openingDirection;        // A variable that can be changed in the inspector to show which side the spawnpoint object is on

    private RoomTemplates templates;        // A variable which will be used to inherit features used in the 'RoomTemplates' script
    private int rand;       // A variable that will be used to store a random integer
    private bool spawned = false;       // A true/false variable used to make sure that rooms don't spawn before checking for overlapping

    void Awake()        // Performs once every time this script is called
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();        // Sets 
        Invoke("Spawn", 0.0001f);         // Loads the Spawn function every set amount of seconds, mainly for testing purposes
    }
    private void Spawn()        // A function used to instantiate the rooms depending on what side the spawnpoint is on
    {
        if (spawned == false)       // Checks if spawned is false and that a new room is ready to be instantiated
        {
            if (openingDirection == 1)      // Checks if the opening direction is 1 (at the top)
            {
                rand = Random.Range(0, templates.bottomRooms.Length);       // Gets a random integer between 0 and the number of bottom doored rooms
                // Spawns a random room with a bottom entrance at the position of the script owner
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)         // Checks if the openingDirection is 2 (at the bottom)
            {
                rand = Random.Range(0, templates.topRooms.Length);      // Gets a random integer between 0 and the number of top doored rooms
                // Spawns a random room with a top entrance at the position of the script owner
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation); //
            }
            else if (openingDirection == 3)         // Checks if the openingDirection is 3 (on the right)
            {
                rand = Random.Range(0, templates.leftRooms.Length);         // Gets a random integer between 0 and the number of left doored rooms
                // Spawns a random room with a left entrance at the position of the script owner
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)         // Checks if the openingDirection is 4 (on the left)
            {
                rand = Random.Range(0, templates.rightRooms.Length);        // Gets a random integer between 0 and the number of right doored rooms
                // Spawns a random room with a right entrance at the position of the script owner
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;         // Sets the spawned bool variable to true so that no rooms can be spawned again
        }
    }

    void OnTriggerEnter2D(Collider2D other)         // Starts when the collider collides with another collider
    {
        if (other.CompareTag("SpawnPoint"))         // Checks if the collided collider belongs to another Spawnpoint using the tag
        {
            if (other.GetComponent<Spawnpoint>().spawned == false && spawned == false)      // Finally checks if the other spawnpoint hasn't spawned anything
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);         // Spawns a closed room which stops adjacent rooms from spawning here
                Destroy(gameObject);        // Removes the game object that this script is attached to
            }
            spawned = true;         // sets spawned to true so that this spawnpoint won't spawn another room
        }
        else        // An else statement to stop the failed if statement from screaming at me
        {
            //shut up
        }
    }
}
