using System.Collections;       // Namespace references that the script can use
using System.Collections.Generic;
using UnityEngine;

// Creates a new tab in the create menu that can be used to make a scriptable object with all of the below parameters included
[CreateAssetMenu(fileName = "New Standard Object", menuName = "Inventory System/Items/Standard")]

public class StandardItem : ItemObject      // The StandardItem class will use features from the ItemObject class
{
    public float healthCha;         // Variable for the health modifier
    public float speedCha;      // Variable for the player movement speed modifier
    public float bulletDamageCha;       // Variable for the bullet damage modifier
    public float bulletSpeedCha;        // Variable for the bullet speed modifier
    public float bulletSizeCha;         // Variable for the bullet size modifier
    public float bulletRangeCha;        // Variable for the bullet range modifier

    public void Awake()         // Performs once every time this script is called
    {
        type = ItemType.Standard;       // Changes the 'type' of the object to 'Standard'
    }
}
