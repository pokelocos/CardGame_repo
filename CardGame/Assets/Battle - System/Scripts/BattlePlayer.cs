using UnityEngine;
using System.Collections;
using CardGame;
using System.Collections.Generic;
using UnityEngine.Events;

public class BattlePlayer : MonoBehaviour, IScripdatableDatable
{
    public CardSet deck;

    public BattleEntity entity_Pref;
    public List<BattleEntity> entities;

    public UnityEvent OnLose;

    public void CopyData(ScriptableObject obj)
    {
        var data = (BattlePlayerData)obj;

        deck = data.deck;
        for (int i = 0; i < data.entities.Count; i++)
        {
            var entity = Instantiate(entity_Pref);
            entity.CopyData(data.entities[i]);
            entities.Add(entity);
        }
    }
}
