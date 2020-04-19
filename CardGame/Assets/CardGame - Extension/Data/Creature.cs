using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GemCardGame
{
    [CreateAssetMenu(fileName = "new Creature Card", menuName = "Card Game/Creature Card...")]
    public class Creature : CardData
    {
        public int life;
        public int damage;
    }
}
