using CardGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GemCardGame
{
    //[CreateAssetMenu(fileName = "new Ceard", menuName = "Card Game/Card...")]
    public class CardData : CardGame.CardData 
    {
        public int cost;

        [Range(0,6)]
        public int slotAmount;
    }
}