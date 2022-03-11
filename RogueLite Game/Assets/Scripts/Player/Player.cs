using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    public float Speed = 2.0f;

    private Vector3 MovementDelta;

    private RaycastHit2D hit;

    public Gameplay gameplay;
    private Text ScoreText;

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

        MovementDelta = new Vector3(x * Speed, y * Speed, 0);

        if (MovementDelta.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (MovementDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, MovementDelta.y), Mathf.Abs(MovementDelta.y * Time.deltaTime), LayerMask.GetMask("Characters", "Blocks"));
        if (hit.collider == null)
        {
            transform.Translate(0, MovementDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(MovementDelta.x, 0), Mathf.Abs(MovementDelta.x * Time.deltaTime), LayerMask.GetMask("Characters", "Blocks"));
        if (hit.collider == null)
        {
            transform.Translate(MovementDelta.x * Time.deltaTime, 0, 0);
        }


    }

    public InventoryObject inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var item = collision.GetComponent<Item>();
        if(item)
        {
            gameplay = FindObjectOfType<Gameplay>();
            gameplay.Score += 10;
            ScoreText = GameObject.Find("Canvas/Score").GetComponent<Text>();
            ScoreText.text = ("Score\n" + gameplay.Score.ToString());

            inventory.AddItem(item.item, 1);
            Destroy(collision.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}