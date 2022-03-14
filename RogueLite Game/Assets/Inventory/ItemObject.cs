using System.Collections;       // Namespace references that the script can use
using System.Collections.Generic;
using UnityEngine;

public enum ItemType        // An enumerator for the different set types of item
{
    Standard        // Used for the basic items in my game (which seem to be all of them right now)
}

public class ItemObject : ScriptableObject      // The ItemObject class will use features from the built-in ScriptableObject class
{
    public GameObject prefab;       // Used to store and 
    public ItemType type;       // Used for showing different types of item in my game
    [TextArea(15, 20)]      // The textbox size for information about the item
    public string description;      // The actual text in the aforementioned textbox
}
