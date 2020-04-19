using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnSystem
{
    [System.Serializable]
    public class TurnManager : MonoBehaviour
    {
        public int turnCount = 0;
        public int actualPhase;       

        public List<PhaseTurn> phases = new List<PhaseTurn>();

        public void Update()
        {
            phases[actualPhase].OnUpdate.Invoke();
        }

        public void NextTurn()
        {
            for (int i = actualPhase; i < phases.Count; i++)
            {
                this.NextPhase();
            }
        }

        #region (->) Phases region

        public void SetPhase(int i)
        {
            if (i >= 0 && i < phases.Count) 
            { 
                phases[actualPhase].OnEnd.Invoke();
                actualPhase = i;
                phases[actualPhase].OnStart.Invoke();
            }
            else
            {
                Debug.Log("Error on the number phase");
            }

        }

        public void NextPhase()
        {
            phases[actualPhase].OnEnd.Invoke();

            if (actualPhase + 1 >= phases.Count) 
                turnCount++;

            actualPhase = (actualPhase + 1) % phases.Count;
            phases[actualPhase].OnStart.Invoke();
        }

        public void AddPhase()
        {
            phases.Add(new PhaseTurn());
        }

        public void RemovePhase(int i)
        {
            try 
            {
                phases.RemoveRange(i, 1);
            }
            catch
            {
                Debug.Log("[Out Range Index]: phase ID ''" + i + "'' dont exist in ''" + this.name + "''.");
            }
        }

        #endregion
    }
}
