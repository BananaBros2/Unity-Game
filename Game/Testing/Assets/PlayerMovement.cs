using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movespeed = 3.0f;

    private Vector2 StartCoords = new Vector2(0.0f,0.0f);

    private Vector2 PreviousPosition = new Vector2(0.0f, 0.0f);

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
    }

    
}
