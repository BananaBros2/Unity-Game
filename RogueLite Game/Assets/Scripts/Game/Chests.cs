using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chests : Collectable
{
    public int CoinAmount = 1;

    public Sprite ChestOpen;
    private Text CoinText;
    private int rand;

    public GameObject coinPrefab;
    public Gameplay gameplay;

    protected override void OnCollect()
    {
        if (!collected)
        {
            gameplay = FindObjectOfType<Gameplay>();
            collected = true;
            GetComponent<SpriteRenderer>().sprite = ChestOpen;

            for (int i = 0; i < CoinAmount; i++)
            {
                rand = Random.Range(360 / CoinAmount * (2*i-1), 360 / CoinAmount * 2 * i);
                Instantiate(coinPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, rand)));
            }
        }
    }
}
