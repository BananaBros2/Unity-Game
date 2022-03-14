using System.Collections;       // Namespace references that the script can use
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       // Used to access and modify aspects of a UI

public class Chests : Collectable       // The Chests class will use features from the Collectable class
{
    public int coinAmount = 1;      // A changable variable for how many coins the chest drops

    public Sprite chestOpen;        // Used to store the sprite of the open chest
    private int rand;       // Starts a variable that will be used to store a random integer

    public GameObject coinPrefab;       // Will be used to instantiate the coin prefabs
    public Gameplay gameplay;       // A variable which will be used to inherit features used in the 'Gameplay' script

    protected override void OnCollect()         // A function from the Collectable script that has been overwritten to activate the same way but do something different
    {
        if (!collected)         // Checks if the object hasn't been collected yet
        {
            gameplay = FindObjectOfType<Gameplay>();        // Finds the hidden Gameplay object and sets it as gameplay
            collected = true;       // Will stop the chest from being opened multiple times
            GetComponent<SpriteRenderer>().sprite = chestOpen;      // Uses the sprite renderer component to swap out the close chest sprite with the open chest sprite

            for (int i = 0; i < coinAmount; i++)        // A for loop which repeats until i is over the given coinAmount value
            {
                rand = Random.Range(360 / coinAmount * (2*i-1), 360 / coinAmount * 2 * i);      // Spits out a coin in a semi-random direction evenly 
                Instantiate(coinPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, rand)));         // Spawns the coin at the random position 
            }
        }
    }
}
