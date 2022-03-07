using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chests : Collectable
{

    public Sprite ChestOpen;
    protected bool collected;
    private Text CoinText;

    void Start()
    {
        GetComponentInParent<UI>().CoinCount = 10;
    }






    protected override void OnCollect()
    {
        Debug.Log("Grant" + CoinCount);
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = ChestOpen;
            Debug.Log("Grant" + CoinCount);
            CoinText = GameObject.Find("Canvas/Coins").GetComponent<Text>();
            CoinText.text = "Test";
        }
    }
}
