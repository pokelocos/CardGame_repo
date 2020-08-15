using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "nNew battle entity data", menuName = "Battle system/Entity data...")]
public class BattleEntityData : ScriptableObject
{
    public int maxLife = 0;
    public int life = 0;
    public Type type;
}
