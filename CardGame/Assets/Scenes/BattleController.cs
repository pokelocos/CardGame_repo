using CardGame;
using GemCardGame;
using System.Collections;
using System.Collections.Generic;
using TurnSystem;
using UnityEngine;

[RequireComponent(typeof(TurnManager))]
public class BattleController : MonoBehaviour // battle controller
{
    public BehaviourCard card_pref;

    public float deltaTimer = 1;
    private float timer = 0;

    private Fighter[] fighter = new Fighter[2];

    private TurnManager turnManager;

    //-------------------- cancer
    

    private CardSet DefaultDeck()
    {
        List<ICard> m1 = new List<ICard>();
        for (int i = 0; i < 30; i++)
        {
            
        }
        
        return new CardSet(m1);
    }


    private void Awake()
    {
        this.turnManager = this.GetComponent<TurnManager>();
        //fighter[0] = new Fighter(30,30,0,10,new CardSet());
        //fighter[1] = new Fighter(30, 30, 0, 10,);
    }

    public void Start()
    {
        
    }

    private void Update()
    {
        if(timer + deltaTimer < Time.time)
        {
            timer = Time.time;
            this.turnManager.NextTurn();
        }
    }

    public void InstantiateCard()
    {
        Instantiate<BehaviourCard>(card_pref);
    }

}
