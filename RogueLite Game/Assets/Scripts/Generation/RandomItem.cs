using System.Collections;       // Namespace references that the script can use
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour         // The AddRoom class will use features from the MonoBehaviour class
{
    public GameObject[] itemTable;        // A list of rooms containing rooms with bottom doors
    private int rand;       // Starts a variable that will be used to store a random integer

    void Start()        // Start is called before the first frame update
    {
        rand = Random.Range(0, itemTable.Length);       // Gets a random integer between 0 and the amount of items in the itemTable array
        Instantiate(itemTable[rand], transform.position, Quaternion.identity);         // Spawns a random item at the game object's position
        Destroy(gameObject);        // Removes itself from the scene after instantitating a random item
    }
}
