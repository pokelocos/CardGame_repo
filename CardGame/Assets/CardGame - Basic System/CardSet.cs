using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame
{
    public class CardSet
    {
        private int maxAmount;

        private List<ICard> cards;

        public CardSet(List<ICard> cards)
        {
            this.cards = cards;
            maxAmount = int.MaxValue;
        }

        public CardSet(List<ICard> cards, int max)
        {
            this.cards = cards;
            maxAmount = max;
        }

        public delegate void CardSetEvent();
        public event CardSetEvent OnEmpty;
        public event CardSetEvent OnFull;

        public void Remove(ICard card)
        {
            var action = cards.Remove(card);

            if (action && cards.Count == 0)
            {
                OnEmpty.Invoke();
            }
        }

        public void Add(ICard card){
           
            if (cards.Count < maxAmount)
            {                
                cards.Add(card);
            }
            if (cards.Count == maxAmount)
            {
                OnFull.Invoke();
            }

        }

        public ICard Get(int i){
            return this.cards[i];
        }

        public int Count()
        {
            return cards.Count;
        }
    }
}
