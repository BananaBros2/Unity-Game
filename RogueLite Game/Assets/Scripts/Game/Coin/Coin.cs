using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : Collectable
{
    public float pickupDelay = 3;

    public int coinAmount = 1;
    private Text coinText;
    private Text scoreText;


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
            gameplay.coinCount += coinAmount;
            coinText = GameObject.Find("Canvas/Coins").GetComponent<Text>();
            coinText.text = ("- " + gameplay.coinCount.ToString());

            gameplay.score += 1;
            scoreText = GameObject.Find("Canvas/Score").GetComponent<Text>();
            scoreText.text = ("Score\n" + gameplay.score.ToString());

            Destroy(gameObject);
        }
    }
}