using UnityEngine;
using System.Collections;

public class BattleEntity : MonoBehaviour, IDamageable, IScripdatableDatable
{
    public int maxLife = 0;
    public int life = 0;
    public Type type;

    public void CopyData(ScriptableObject obj)
    {
        var data = (BattleEntityData)obj;

        this.maxLife = data.maxLife;
        this.life = data.life;
        this.type = data.type;
    }

    public void GetDamage(int damage)
    {
        if (damage < 0) damage = 0;

        life -= damage;
        if(life <= 0)
        {
            IsDeath();
        }
    }

    public void GetHeal(int heal)
    {
        if (heal < 0) heal = 0;

        life = Mathf.Min(heal+life,maxLife);
    }

    public bool IsDeath()
    {
        throw new System.NotImplementedException();
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
