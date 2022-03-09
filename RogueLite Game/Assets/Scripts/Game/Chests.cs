using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chests : Collectable
{
    public int CoinAmount = 1;
    public Sprite ChestOpen;
    private Text CoinText;

    public Gameplay gameplay;

    private void Start()
    {
        gameplay = FindObjectOfType<Gameplay>();
        Debug.Log(gameplay.CoinCount);
    }

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = ChestOpen;
            gameplay.CoinCount += CoinAmount;
            Debug.Log("Grant 5");
            CoinText = GameObject.Find("Canvas/Coins").GetComponent<Text>();
            CoinText.text = (gameplay.CoinCount.ToString());
        }
    }
}
