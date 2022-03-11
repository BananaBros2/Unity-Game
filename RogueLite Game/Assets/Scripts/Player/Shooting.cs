using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float fireDelay = 0.4f;
    float cooldownTimer = 0;

    private float rotationX;
    private float rotationY;

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        rotationX = 0;
        rotationY = 0;


        if (Input.GetAxisRaw("Horizontal Shoot") > 0)
        {
            rotationX = 360;
        }
        else if (Input.GetAxisRaw("Horizontal Shoot") < 0)
        {
            rotationX = 180;
        }



        if (Input.GetAxisRaw("Vertical Shoot") > 0)
        {
            rotationY = 90;
            if (rotationX == 360)
            {
                rotationX = 0.0001f;
            }
        }
        else if (Input.GetAxisRaw("Vertical Shoot") < 0)
        {
            rotationY = 270;
        }

        if(rotationY == 0)
        {
            rotationY = rotationX;
        }

        if (rotationX == 0)
        {
            rotationX = rotationY;
        }


        if ((Input.GetButton("Horizontal Shoot") || Input.GetButton("Vertical Shoot")) && cooldownTimer <= 0)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, ((rotationY + rotationX) / 2))));
            cooldownTimer = fireDelay;
        }
    }
}
