using CardGame;
using DataSystem;
using GemCardGame;
using MapSystem;
using System.Collections;
using System.Collections.Generic;
using TurnSystem;
using UnityEngine;

[RequireComponent(typeof(TurnManager))]
public class BattleController : MonoBehaviour // battle controller
{
    [Header("Arena")]
    public Vector2 size = new Vector2(10,5);
    private Map map;

    public BehaviourCard card_pref;

    public float deltaTimer = 1;
    private float timer = 0;

    private TurnManager turnManager;
    public BattlePlayer player_pref;
    private List<BattlePlayer> players;

    //---------------Unity Editor Area---------------
    [Header("Unity Editors Test Data")]
    public BattleEntityData testPlayer;
    public BattleEntityData testEnemy;

    private void Awake()
    {
        this.turnManager = this.GetComponent<TurnManager>();
        this.map = MapGenerator.GenerateMapArenaBattle((int)size.x,(int)size.y);
    }

    public void Start()
    {
        var data = DataManager.LoadData<Data>();
        if(data != null)
        {
            // implementar que funcione con las partidas guardadas
        }
        else
        {
            // esto pasa solo cuando se inicia la escena por un flujo anormal (modo test)
            var player = Instantiate(player_pref);
            player.CopyData(testPlayer);
            var enemy = Instantiate(player_pref);
            enemy.CopyData(testEnemy);
            players.Add(player);
            players.Add(enemy);
        }

    }

    private void Update()
    {
        if(timer + deltaTimer < Time.time)
        {
            timer = Time.time;
            this.turnManager.NextTurn();
        }
    }

    private void SetFigther()
    {

    }
}
