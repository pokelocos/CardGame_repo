using UnityEngine;
using System.Collections;
using System.Reflection;
using System.Linq;
using System;

namespace CardGame
{
    [System.Serializable]
    public abstract class Property : IScripdatableDatable
    {
        public static char spliterChar = '_';

        public string tag;

        public virtual string GetText() { return ""; }

        public virtual string ToStringCode() { return this.GetType().Name; }

        public static void StringcodeToObj(out Property property , string code)
        {
            var subclassTypes = Assembly.GetAssembly(typeof(Property)).GetTypes().Where(t => t.IsSubclassOf(typeof(Property)));
            foreach (var subclass in subclassTypes)
            {
                if(subclass.Name == code)
                {
                    var instance = (Property)Activator.CreateInstance(subclass);
                    instance.SetObj(code);
                }
            }

            property = null;
        }

        public abstract void SetObj(String valuesCode);
        public abstract void CopyData(ScriptableObject obj);
    }
}