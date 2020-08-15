using CardGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card //: ICard
{
    public int cardDataId;
    public List<Gem> gems;

    public Card(CardData cardData)
    {
        //this.cardDataId = cardData.id;
    }
}
