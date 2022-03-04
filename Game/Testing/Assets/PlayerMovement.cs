using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movespeed = 3.0f;

    private Vector2 StartCoords = new Vector2(0.0f,0.0f);

    private Vector2 PreviousPosition = new Vector2(0.0f, 0.0f);

    public Transform Sword;

    // Start is called before the first frame updat
    void Start()
    {

        StartCoords = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PreviousPosition = transform.position;

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        float verticalInput = Input.GetAxisRaw("Vertical");

        var currentspd = movespeed * Time.deltaTime * (2);

        transform.Translate(horizontalInput * currentspd,  verticalInput * currentspd, 0);

        if (Input.GetAxisRaw("Fire1") > 0)
        {
            Sword = this.gameObject.transform.GetChild(0);
            float rotAmount =+ 36f;
            float curRot = transform.localRotation.eulerAngles.z;
            Sword.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));
        }
        else if (Input.GetAxisRaw("Fire1") == 0)
        {
            Sword = this.gameObject.transform.GetChild(0);
            float rotAmount = 0;
            float curRot = transform.localRotation.eulerAngles.z;
            Sword.transform.localRotation = Quaternion.identity;
        }



    }

    
}
