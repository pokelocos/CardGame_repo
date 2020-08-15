using UnityEngine;
using System.Collections;
using CardGame;
using System.Collections.Generic;

[SerializeField]
[CreateAssetMenu(fileName = "New battle player data", menuName = "Battle system/Player data...")]
public class BattlePlayerData : ScriptableObject
{
    public CardSet deck;
    public List<BattleEntityData> entities;
}
