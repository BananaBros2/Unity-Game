using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expire : Collidable
{
    public float timer = 1f;
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        Debug.Log(coll.tag);
        if (coll.CompareTag("HardCollision"))
        {
            Destroy(gameObject);
        }
    }
}
