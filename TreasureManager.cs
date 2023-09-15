using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureManager : MonoBehaviour
{
    Treasures treasures;
    void Start()
    {
        treasures = new Treasures();
    }

    public void Take(ItemValue itemValue)
    {
        treasures.Coins -= itemValue.Coins;
        treasures.Mana -= itemValue.Mana;
        treasures.Wood -= itemValue.Wood;
        treasures.Stone -= itemValue.Stone;
    }

    public void Add(ItemValue itemValue)
    {
        treasures.Coins += itemValue.Coins;
        treasures.Mana += itemValue.Mana;
        treasures.Wood += itemValue.Wood;
        treasures.Stone += itemValue.Stone;
    }

    public void Show()
    {
        treasures.Show();
    }

}
