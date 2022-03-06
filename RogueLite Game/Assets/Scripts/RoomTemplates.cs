using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] obstacles;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;

    private int rand;

    private void Update()
    {
        if(waitTime <= 0 && spawnedBoss == false)
        {
            Instantiate(boss, rooms[rooms.Count-1].transform.position, Quaternion.identity);
            spawnedBoss = true;
            
            for (int i = 1; i < rooms.Count-1; i++)
            {
                rand = Random.Range(0, obstacles.Length);
                Instantiate(obstacles[rand], rooms[i].transform.position, rooms[i].transform.rotation);
            }
            
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}