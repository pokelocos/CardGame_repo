using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapSystem;

namespace DataSystem
{
    [System.Serializable]
    public class Data
    {
        public MainData main;
        public Run run;
        public Battle battle;

        public Data()
        {
        }
    }

    [System.Serializable]
    public class MainData
    {

    }

    [System.Serializable]
    public class Run
    {
        public Character player;

        public Map map;
        public Character[] enemies; 

        public Run(Character player,Map map, Character[] enemies = null)
        {
            this.player = player;
            this.map = map;
            this.enemies = enemies;
        }
    }

    [System.Serializable]
    public class Battle
    {

        public Map board;
        public Tuple<int, int> playerPos;
        public Tuple<Character[], Tuple<int, int>>[] enemies;

        public Battle(Map board)
        {
            this.board = board;
        }
    }
}