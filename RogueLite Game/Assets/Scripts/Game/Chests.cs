using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chests : Collectable
{
    public int coinAmount = 1;

    public Sprite chestOpen;
    private Text coinText;
    private int rand;

    public GameObject coinPrefab;
    public Gameplay gameplay;

    protected override void OnCollect()
    {
        if (!collected)
        {
            gameplay = FindObjectOfType<Gameplay>();
            collected = true;
            GetComponent<SpriteRenderer>().sprite = chestOpen;

            for (int i = 0; i < coinAmount; i++)
            {
                rand = Random.Range(360 / coinAmount * (2*i-1), 360 / coinAmount * 2 * i);
                Instantiate(coinPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, rand)));
            }
        }
    }
}
