using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : Collectable
{
    public float pickupDelay = 5;

    public int CoinAmount = 1;
    private Text CoinText;
    private Text ScoreText;


    public Gameplay gameplay;

    void LateUpdate()
    {
        pickupDelay -= Time.deltaTime;
    }

    protected override void OnCollect()
    {
        pickupDelay -= Time.deltaTime;
        if (!collected && pickupDelay <= 0)
        {
            gameplay = FindObjectOfType<Gameplay>();
            gameplay.CoinCount += CoinAmount;
            CoinText = GameObject.Find("Canvas/Coins").GetComponent<Text>();
            CoinText.text = ("- " + gameplay.CoinCount.ToString());

            gameplay.Score += 1;
            ScoreText = GameObject.Find("Canvas/Score").GetComponent<Text>();
            ScoreText.text = ("Score\n" + gameplay.Score.ToString());

            Destroy(gameObject);
        }
    }
}