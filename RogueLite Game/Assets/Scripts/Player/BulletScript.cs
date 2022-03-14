using System.Collections;       // Namespace references that the script can use
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : Collidable      // The BulletScript class will use features from the Collidable class
{
    public float bulletSpeed = 10f;         // Sets a float variable for 'bulletSpeed' to a default value of 10 which can be changed in the inspector

    protected virtual void Update()       // Update is called once per frame
    {
        Vector3 velocity = new Vector3(bulletSpeed * Time.deltaTime, 0f, 0f);       // Sets a 'velocity' variable X value to the speed times delta time
        transform.position += transform.rotation * velocity;        // Adds the rotation of the object multiplied by the velocity to the position
    }

    void OnTriggerEnter2D(Collider2D other)         // Starts when the collider2D overlaps with another collider2D which is set to 'other'
    {
        if (other.CompareTag("HardCollision"))      // Checks if the entered collider has the tag 'HardCollision'
        {
            Destroy(gameObject);        // Removes the game object that this script is attached to
        }
    }
}
