using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : Collectable
{

    public Sprite ChestOpen;
    public int CoinCount = 10;

    protected override void OnCollect()
    {
        Debug.Log("Grant" + CoinCount);
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = ChestOpen;
            Debug.Log("Grant" + CoinCount);
        }
    }
}
