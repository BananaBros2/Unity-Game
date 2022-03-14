using System.Collections;       // Namespace references that the script can use
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour      // The RoomTemplates class will use features from the MonoBehaviour class
{
    public GameObject[] bottomRooms;        // A list of rooms containing rooms with bottom doors
    public GameObject[] topRooms;       // A list of rooms containing rooms with top doors
    public GameObject[] leftRooms;      // A list of rooms containing rooms with left doors
    public GameObject[] rightRooms;         // A list of rooms containing rooms with right doors
    public GameObject[] obstacles;      // A list of room overlays consisting of obstacles

    public GameObject boss;         // The final room to be generated
    public GameObject closedRoom;       // The closed off room game object is stored here

    public List<GameObject> rooms;      // A list of the current rooms on the map


    public float waitTime;      // The wait time before a boss room is spawned
    private bool spawnedBoss;       // A true or false variable for tracking whether or not the boss room has been spawned

    private int rand;       // A variable that will be used to store a random integer

    private void Update()              // Update is called once per frame
    {
        if(waitTime <= 0 && spawnedBoss == false)       // Checks to see if it is time to spawn a boss room and if one has already been spawned.
        {
            Instantiate(boss, rooms[rooms.Count-1].transform.position, Quaternion.identity);        // Spawns a boss room at the position of the last spawned room
            spawnedBoss = true;         // Sets the spawnedBoss variable to true so that another boss room isn't added
            
            for (int i = 1; i < rooms.Count-1; i++)         // Will instantiate an obstacle on every room minus the boss room and starting room
            {
                rand = Random.Range(0, obstacles.Length);       // Sets the rand variable as an integer between 0 and the number of objects in the obstacles array
                Instantiate(obstacles[rand], rooms[i].transform.position, rooms[i].transform.rotation);         // Spawns a random obstacle from the obstacles list
            }
            
        }
        else        // Will be performed if the previous statement(s) failed
        {
            waitTime -= Time.deltaTime;         // Takes away the time since last frame from the 'waitTime' variable
        }
    }
}