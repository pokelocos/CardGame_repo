using UnityEngine;
using System.Collections;

public interface IScripdatableDatable
{
    void CopyData(ScriptableObject obj);

    void SetObj(string valuesCode);
    string ToStringCode();
}
