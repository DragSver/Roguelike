using System;
using UnityEngine;

[Serializable]
public struct CardStats
{
    public string Name;
    public Sprite Image;
    public string Description;
    
    public int Heal;
    public int Defense;
    public int Damage;
    public int CountAddCards;
    public int CountCardsInDeck;

    public CardStats(int heal, int damage, int defense, int countAddCards, string name, string description,
        Sprite image, int countCardsInHand)
    {
        Name = name;
        Description = description;
        Image = image;
        Heal = heal;
        Damage = damage;
        Defense = defense;
        CountAddCards = countAddCards;
        CountCardsInDeck = countCardsInHand;
    }
}
