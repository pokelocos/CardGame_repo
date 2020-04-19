using System;
using System.Collections.Generic;

namespace DataSystem
{
    [System.Serializable]
    public class Character
    {
        public Tuple<float, float> position;
        public string rolTag;
        public int hp;
        public List<Card> extraCards;
        public List<Gem> extraGems;
        public List<Card> deck;

        public Character(string rolTag, int hp, List<Card> deck, List<Card> extraCards, List<Gem> extraGems,Tuple<float,float> position = null)
        {
            this.rolTag = rolTag;
            this.hp = hp;
            this.extraCards = extraCards;
            this.extraGems = extraGems;
            this.deck = deck;
            this.position = position;
        }
    }
}