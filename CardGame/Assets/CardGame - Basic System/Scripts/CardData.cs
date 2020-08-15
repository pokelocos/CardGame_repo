using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New card data", menuName = "Card game/Card data...")]
    public class CardData : ScriptableObject // esto tendria que sacarlo de aqui 
    {
        public List<Property> properties;
    }
}
