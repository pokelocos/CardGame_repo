using DataSystem;
using DungeonSystem;
using MapSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    public Transform PivotMap;
    public Vector2 tileDelta;
    private List<BehaviourTile> BehaviorsTiles = new List<BehaviourTile>();

    public CharacterContoller player;
    public List<MapCharacterBehaviour> enemies;

    //prefs
    public BehaviourTile tile_Pref;
    public List<MapCharacterBehaviour> enemies_Pref;

    void Start()
    {
        var data = DataManager.LoadData<Data>();
        if (data == null)
        {
            data = DataManager.NewData<Data>();
        }
        if (data.run.map == null)
        {
            //Genero el mapa
            data.run.map = MapGenerator.GenerateMap(20, 20, 100, 3);

            // Calculo la posicion del jugador
            System.Random r = new System.Random();
            var tile = data.run.map.tiles[r.Next(0, data.run.map.tiles.Length)];
            data.run.player.position = new System.Tuple<float, float> (tile.position.Item1, tile.position.Item2);

            // Genero los enemigos
            for (int i = 0; i < 10; i++)
            {
                tile = data.run.map.tiles[r.Next(0, data.run.map.tiles.Length)];

                /*
                foreach (var t in data.run.map.tiles)
                {
                    if (player.character.tile == tile)
                    {
                        return true;
                    }

                    foreach (var e in enemies)
                    {
                        if (e.tile == tile)
                        {
                            return true;
                        }
                    }

                }
                if (IsOccupied(tile))
                {
                    i--;
                    continue;
                }

                //var enemy = Instantiate(enemies_Pref[r.Next(0, enemies_Pref.Count)]);
                enemy.transform.position = tile.transform.position;
                enemy.tile = tile;
                enemies.Add(enemy);
                */
            }
            //data.run.enemies 
        }

        DataManager.SaveData<Data>(data);

        InstanceMap(data.run.map);


        //Inicio Random (cambiar)
        System.Random rand = new System.Random();
        var startTile = BehaviorsTiles[rand.Next(0, BehaviorsTiles.Count)];
        player.transform.position = startTile.transform.position;
        player.character.tile = startTile;

        for (int i = 0; i < 10; i++)
        {
            startTile = BehaviorsTiles[rand.Next(0, BehaviorsTiles.Count)];
            if (IsOccupied(startTile))
            {
                i--;
                continue;
            }

            var enemy = Instantiate(enemies_Pref[rand.Next(0, enemies_Pref.Count)]);
            enemy.transform.position = startTile.transform.position;
            enemy.tile = startTile;
            enemies.Add(enemy);
        }

        // al finalizar el movimiento del jugador
        player.character.OnFinishMove.AddListener(() =>
        {
            // pregunto si estoy en la misma casilla que un enemigo
            var oponent = CheckBattle();
            if (oponent != null)
            {
                SceneManager.LoadScene("Battle");
            }

            // todos los enemigos se mueven
            foreach (var enemy in enemies)
            {
                var neighbors = new List<BehaviourTile>();

                foreach (var tile in enemy.tile.neighbors)
                {
                    foreach (var other in enemies)
                    {
                        if (other != enemy && other.tile != tile)
                        {
                            neighbors.Add(tile);
                        }
                    }
                }
                enemy.Move(neighbors[rand.Next(0, neighbors.Count)]);
            }
        });

        // al finalizar el movimiento del los enemigos
        foreach (var enemy in enemies)
        {
            // pregunto si estoy en la misma casilla que el player
            enemy.OnFinishMove.AddListener(() =>
            {
                if (enemy.tile == player.character.tile)
                {
                    SceneManager.LoadScene("Battle");
                }
            });
        }
    }

    private MapCharacterBehaviour CheckBattle()
    {
        foreach (var enemy in enemies)
        {
            if(enemy.tile == player.character.tile)
            {
                return enemy;
            }
        }
        
        return null;
    }

    private bool IsOccupied(BehaviourTile tile)
    {
        if (player.character.tile == tile)
        {
            return true;
        }

        foreach (var e in enemies)
        {
            if (e.tile == tile)
            {
                return true;
            }
        }

        return false;
    }
   

    private void InstanceMap(Map map)
    {
        for (int i = 0; i < map.tiles.Length; i++)
        {
            var tile = Instantiate(tile_Pref, map.tiles[i].Position * tileDelta, Quaternion.identity, PivotMap);
            tile.Initialize(map.tiles[i]);
            this.BehaviorsTiles.Add(tile);
        }

        foreach (var tile in this.BehaviorsTiles)
        {
            var neigh = map.GetNeighbors(tile.tileData);
            for (int i = 0; i < neigh.Length; i++)
            {
                foreach (var other in this.BehaviorsTiles)
                {
                    if (other.tileData == neigh[i])
                    {
                        tile.neighbors.Add(other);
                    }
                }
            }
        }
    }
}
