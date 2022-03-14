using System.Collections;       // Namespace references that the script can use
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]       // Adds any required components as dependencies
public class Collidable : MonoBehaviour         // The Collidable class will use features from the MonoBehaviour class
{
    public ContactFilter2D filter;      // Only returns select results
    private BoxCollider2D boxCollider;      // Sets the boxCollider as a variable
    private Collider2D[] hits = new Collider2D[30];         // Makes a 'hits' array that only stores 30 items

    protected virtual void Start()      // Start is called before the first frame update
    {
        boxCollider = GetComponent<BoxCollider2D>();        // Sets the object's boxcollider2D to boxCollider
    }

    protected virtual void Update()         // Update is called once per frame
    {
        boxCollider.OverlapCollider(filter, hits);      // Gets a list of all the objects collided  with
        for (int i = 0; i < hits.Length; i++)       // A for loop that repeats until i has gone through the entire hits list
        {
            if (hits[i] == null)        // If the hit was nothing then ignore the item
            {
                continue;       // Skips the next instructions and begins the next iteration of the loop
            }
            OnCollide(hits[i]);         // Tells the OnCollide function what object it collided with

            hits[i] = null;         // Removes the item from the list
        }
    }

    protected virtual void OnCollide(Collider2D coll)       // A function which will be used and activated when an object collides
    {
        
    }
}