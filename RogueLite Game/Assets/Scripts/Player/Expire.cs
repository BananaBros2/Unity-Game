using System.Collections;       // Namespace references that the script can use
using System.Collections.Generic;
using UnityEngine;

public class Expire : MonoBehaviour         // The Expire class will use features from the MonoBehaviour class
{
    public float timer = 0.5f;        // The timer variable for when the object will be deleted
    void Update()       // Update is called once per frame
    {
        timer -= Time.deltaTime;        // The amount of seconds it took for the engine to process the previous frame is taken away from 'timer'

        if (timer <= 0)         // If the timer is or has gone below 0, then perform the contents
        {
            Destroy(gameObject);        // Removes the game object that this script is attached to
        }
    }
}
