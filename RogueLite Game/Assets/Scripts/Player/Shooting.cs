using System.Collections;       // Namespace references that the script can use
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour       // The Shooting class will use features from the MonoBehaviour class
{
    public GameObject bulletPrefab;         // Used to store the player bullet prefab

    public float fireDelay = 0.4f;      //  The set amount of seconds the player can't shoot between shots
    float cooldownTimer = 0;        // The varaible that holds the amount of seconds before the next shot

    private float rotationX;        // Starts a variable for the calculating the Z rotation
    private float rotationY;        // Starts a second variable for the calculating the Z rotation

    void Update()       // Update is called once per frame
    {
        cooldownTimer -= Time.deltaTime;        // Takes away the time since last frame from the cooldownTimer varaible

        rotationX = 0;      // Resets the variable for the calculating the Z rotation
        rotationY = 0;      // Resets the second variable for the calculating the Z rotation

        if (Input.GetAxisRaw("Horizontal Shoot") > 0)       // Checks if the player is holding the positive horizontal key
        {
            rotationX = 360;        // Sets the rotationX variable to 360
        }
        else if (Input.GetAxisRaw("Horizontal Shoot") < 0)      // Checks if the player is holding the negative horizontal key
        {
            rotationX = 180;        // Sets the rotationX variable to 180
        }

        if (Input.GetAxisRaw("Vertical Shoot") > 0)         // Checks if the player is holding the positive vertical key
        {
            rotationY = 90;         // Sets the rotationY variable to 90
            if (rotationX == 360)       // Checks if the rotationX variable is 360
            {
                rotationX = 0.0001f;        // Sets the rotationX variable to almost but not 0
            }
        }
        else if (Input.GetAxisRaw("Vertical Shoot") < 0)        // Checks if the player is holding the negative vertical key
        {
            rotationY = 270;        // Sets the rotationY variable to 270
        }

        if (rotationY == 0)      // Checks if the rotationY variable is 0
        {
            rotationY = rotationX;      // Sets the rotationY variable to whatever the rotationX variable currently is
        }

        if (rotationX == 0)         // Checks if the rotationX variable is exactly 0
        {
            rotationX = rotationY;      // Sets the rotationX variable to whatever the rotationY variable currently is
        }


        // Checks if any of the shooting buttons are being pressed and if the cooldown timer is or below 0
        if ((Input.GetButton("Horizontal Shoot") || Input.GetButton("Vertical Shoot")) && cooldownTimer <= 0)       
        {
            // Creates the bullet prefab at the position of the script owner, the Z rotation is set to the mean of the rotation variables
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, ((rotationY + rotationX) / 2))));
            cooldownTimer = fireDelay;      // Resets the cooldown timer
        }
    }
}
