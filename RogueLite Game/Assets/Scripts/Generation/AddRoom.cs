using System.Collections;       // Namespace references that the script can use
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour        // The AddRoom class will use features from the MonoBehaviour class
{
    private RoomTemplates templates;        // A variable which will be used to inherit features used in the 'Gameplay' script

    private void Start()        // Start is called before the first frame update
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();        // Finds the script of the object with all the room shapes
        templates.rooms.Add(this.gameObject);       // Adds the owner of this script to the 'rooms' array in the RoomTemplates script
    }
}
