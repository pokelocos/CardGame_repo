using UnityEngine;
using System.Collections;

namespace CardGame
{
    [System.Serializable]
    public class ValueString : Property
    {
        public string value;

        public override string GetText() { return value; }

        public override void SetObj(string valuesCode)
        {
            value = valuesCode;
        }

        public override string ToStringCode() { return base.ToStringCode() + Property.spliterChar + value; }
    }

}
