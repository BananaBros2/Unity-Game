using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    public float speed = 2.0f;

    private Vector3 movementDelta;

    private RaycastHit2D hit;

    public Gameplay gameplay;
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movementDelta = new Vector3(x * speed, y * speed, 0);

        if (movementDelta.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movementDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, movementDelta.y), Mathf.Abs(movementDelta.y * Time.deltaTime), LayerMask.GetMask("Characters", "Blocks"));
        if (hit.collider == null)
        {
            transform.Translate(0, movementDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(movementDelta.x, 0), Mathf.Abs(movementDelta.x * Time.deltaTime), LayerMask.GetMask("Characters", "Blocks"));
        if (hit.collider == null)
        {
            transform.Translate(movementDelta.x * Time.deltaTime, 0, 0);
        }


    }

    public InventoryObject inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var item = collision.GetComponent<Item>();
        if(item)
        {
            gameplay = FindObjectOfType<Gameplay>();
            gameplay.score += 10;
            scoreText = GameObject.Find("Canvas/Score").GetComponent<Text>();
            scoreText.text = ("score\n" + gameplay.score.ToString());

            inventory.AddItem(item.item, 1);
            Destroy(collision.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.container.Clear();
    }
}