using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Standard Object", menuName = "Inventory System/Items/Standard")]
public class StandardItem : ItemObject
{
    public float healthCha;
    public float speedCha;
    public float bulletDamageCha;
    public float bulletSpeedCha;
    public float bulletSizeCha;
    public float bulletRangeCha;
    public void Awake()
    {
        type = ItemType.Standard;
    }
}
