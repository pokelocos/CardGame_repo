using UnityEngine;
using System.Collections;
using System;

namespace CardGame
{
    [System.Serializable]
    public class ValueInt : Property
    {
        

        public int value;

        public override void CopyData(ScriptableObject obj)
        {
            throw new NotImplementedException();
        }

        public override string GetText() { return value.ToString(); }

        public override void SetObj(string valuesCode)
        {
            value = Convert.ToInt32(new string(valuesCode[0], 1));
        }

        public override string ToStringCode() { return base.ToStringCode() + Property.spliterChar + value; }
    }

}