using GemCardGame;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Character", menuName = "Card Game/Character...")]
public class CharacterData : ScriptableObject
{
    public Sprite image;
    public string characterTag;
    public int hp;
    public int mp;
    public string description;

    public List<CardData> cardsData;
    //public List<GemData> gems;

    public List<Card> GetCards()
    {
        var toReturn = new List<Card>();
        foreach (var cardData in cardsData)
        {
            toReturn.Add(new Card(cardData));
        }
        return toReturn;
    }
}