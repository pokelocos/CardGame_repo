using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TurnSystem
{
    [System.Serializable]
    public class PhaseTurn : ScriptableObject
    {
        public string name = "Name phase";

        public UnityEvent OnStart;
        public UnityEvent OnEnd;
        public UnityEvent OnUpdate;
    }
}
