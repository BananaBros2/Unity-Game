using System.Collections;       // Namespace references that the script can use
using System.Collections.Generic;
using UnityEngine;

public class CoinProjectile : MonoBehaviour         // The CoinProjectile class will use features from the MonoBehaviour class
{
    private float rand;         // Starts the variable which will be used for storing a random float number
    public float coinSpeed = 10f;       // Sets the starting speed of the coin      

    private void Start()        // Start is called before the first frame update
    {
        rand = Random.Range(0.05f, 0.75f);      // Sets rand to random number between 0.05 and 0.75
    }


    void Update()       // Update is called once per frame
    {
        Vector3 velocity = new Vector3(coinSpeed * Time.deltaTime, 0f, 0f);         // Makes a new Vector3 'velocity' variable which will be reset every frame
        transform.position += transform.rotation * velocity;       // Adds the rotation of the object multiplied by the velocity to the position
        if (coinSpeed > 0)      // Checks if the 'CoinSpeed' variable is over 0
        {
            coinSpeed = coinSpeed - rand;       // Take away the set random number from the speed
        }
        else if (coinSpeed < 0)         // If the speed is under a value of 0
        {
            coinSpeed = 0;      // Sets the speed to exactly 0 so the coin doesn't suddenly reverse direction
            transform.rotation = Quaternion.identity;       // Sets the rotation of every axis to 0
        }
    }
}

