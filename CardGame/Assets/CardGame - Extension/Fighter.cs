using CardGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GemCardGame
{
    public class Fighter // battle player
    {
        private int maxHp, hp;
        private int maxMp, mp;

        private CardSet deck;
        private CardSet hand;
        private CardSet graveyard;

        public Fighter(int hp, int maxHp, int mp, int maxMp, CardSet deck)
        {
            this.maxHp = maxHp;
            this.maxMp = maxMp;

            this.hp = hp;
            this.mp = mp;

            this.deck = deck;
            //this.hand = new CardSet();
            //this.graveyard = new CardSet();
        }
    }
}