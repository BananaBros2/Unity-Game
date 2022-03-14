using System.Collections;       // Namespace references that the script can use
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       // Used to access and modify aspects of a UI

public class Player : MonoBehaviour         // The player class will use features from the MonoBehaviour class
{

    private BoxCollider2D boxCollider;      // A variable which will be used to access (Box)Collider2D functionalities
    public float speed = 2.0f;      // Sets a new float variable 'speed' as 2 which can be changed in the unity inspector
    private Vector3 movementDelta;      // Vector3 variables can be used to perform vector operations
    private RaycastHit2D hit;       // Used to access information returned by a raycast when hitting objects
    public Gameplay gameplay;       // A variable which will be used to inherit features used in the 'Gameplay' script
    private Text scoreText;         // Will be used to add and update the score
    float x;
    float y;

    void Start()        // Start is called before the first frame update
    {
        boxCollider = GetComponent<BoxCollider2D>();        // Finds the BoxCollider2D component the owner has and assigns it to 'boxCollider'
    }

    void Update()       // Update is called once per frame
    {
        x = Input.GetAxisRaw("Horizontal");       // Sets the new variable 'x' based on the player's input.
        y = Input.GetAxisRaw("Vertical");         // Depending what the player is pressing, it could be 1, 0, or -1 (keyboard)

        movementDelta = new Vector3(x * speed, y * speed, 0);       // Sets movementDelta as the player's input multiplied by the speed variable



        if (movementDelta.x > 0)        // If the X value in movementDelta is over 0 then it will perform the contents
        {
            transform.localScale = new Vector3(1, 1, 1);        // Will transform the player game object to regular scale
        }
        else if (movementDelta.x < 0)       // If the x value is under 0 and the previous was unsuccessful, it will perform these
        {
            transform.localScale = new Vector3(-1, 1, 1);       // Will transform and flip the player game object horizontally
        }


        // Creates a box at the player which collides with/detects objects on the Characters and Blocks layers
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, movementDelta.y), Mathf.Abs(movementDelta.y * Time.deltaTime), LayerMask.GetMask("Characters", "Blocks"));
        if (hit.collider == null)       // Checks if the boxcast hit anything
        {
            transform.Translate(0, movementDelta.y * Time.deltaTime, 0);        // Moves the player along the Y axis based on delta time
        }

        // Does the same, but for the X value
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(movementDelta.x, 0), Mathf.Abs(movementDelta.x * Time.deltaTime), LayerMask.GetMask("Characters", "Blocks"));
        if (hit.collider == null)       // Checks if the boxcast hit anything
        {
            transform.Translate(movementDelta.x * Time.deltaTime, 0, 0);        // Moves the player along the X axis based on delta time
        }
    }


    public InventoryObject inventory;       // A variable used to inherit features used in the 'InventoryObject' script

    private void OnTriggerEnter2D(Collider2D collision)         // Starts if the collider overlaps with another collider
    {
        var item = collision.GetComponent<Item>();      // Starts a new variable which holds the hit item
        if (item)        // Checks if the item assignment was successful
        {
            gameplay = FindObjectOfType<Gameplay>();        // Finds the Gameplay script and sets it as the gameplay variable
            gameplay.score += 10;       // Adds 10 to the total score
            scoreText = GameObject.Find("Canvas/Score").GetComponent<Text>();       // Finds and sets the Score's text component as scoreText
            scoreText.text = ("Score\n" + gameplay.score.ToString());       // Changes the score text to "Score " with the total score on the next line

            inventory.AddItem(item.item, 1);        //
            Destroy(collision.gameObject);      // Removes the game object that was collided with
        }
    }

    private void OnApplicationQuit()        // Triggers when the application is closed
    {
        inventory.container.Clear();        // Removes all items in the inventory
    }
}