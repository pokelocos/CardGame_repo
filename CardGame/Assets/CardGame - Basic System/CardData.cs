using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame
{
    public class CardData : ScriptableObject // esto tendria que sacarlo de aqui 
    {
        // Visual
        public Sprite image;
        public string cardName;
        public string abilityText;

        // Tecnico
        public int id;

    }
}
