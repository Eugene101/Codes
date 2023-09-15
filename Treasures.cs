using UnityEngine;

public class Treasures
{
    int coins = 5;
    int mana = 5;
    int wood = 5;
    int stone = 5;

    public int Coins { get => coins; set => coins = value; }
    public int Mana
    {
        get => mana;
        set
        {
            if (value >= 0)
            {
                mana = value;
            }
        }
    }

    public int Wood
    {
        get => wood;
        set
        {
            if (value >= 0)
            {
                wood = value;
            }
        }
    }

    public int Stone
    {
        get => stone;
        set
        {
            if (value >= 0)
            {
                stone = value;
            }
        }
    }

    public void Show()
    {
        Debug.Log("Coins " + coins + " Mana " + mana + " Wood " + wood + " Stone " + stone);
    }
}
