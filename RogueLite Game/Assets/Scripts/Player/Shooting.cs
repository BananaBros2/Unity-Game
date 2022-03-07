using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float fireDelay = 0.4f;
    float cooldownTimer = 0;

    private float RotationX;
    private float RotationY;

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        RotationX = 0;
        RotationY = 0;


        if (Input.GetAxisRaw("Horizontal Shoot") > 0)
        {
            RotationX = 360;
        }
        else if (Input.GetAxisRaw("Horizontal Shoot") < 0)
        {
            RotationX = 180;
        }



        if (Input.GetAxisRaw("Vertical Shoot") > 0)
        {
            RotationY = 90;
            if (RotationX == 360)
            {
                RotationX = 0.0001f;
            }
        }
        else if (Input.GetAxisRaw("Vertical Shoot") < 0)
        {
            RotationY = 270;
        }

        if(RotationY == 0)
        {
            RotationY = RotationX;
        }

        if (RotationX == 0)
        {
            RotationX = RotationY;
        }


        if ((Input.GetButton("Horizontal Shoot") || Input.GetButton("Vertical Shoot")) && cooldownTimer <= 0)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, ((RotationY + RotationX) / 2))));
            cooldownTimer = fireDelay;
        }
    }
}
