using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

namespace MapSystem
{
    [System.Serializable]
    public class Map
    {
        public Tile[] tiles;
        public Tuple<int, int>[] links;

        public Map(Tile[] tiles, Tuple<int, int>[] links = null)
        {
            this.tiles = tiles;
            this.links = links;
        }

        public Tile[] GetNeighbors(Tile tile)
        {
            List<Tile> toReturn = new List<Tile>();

            var id = GetTileId(tile);
            for (int i = 0; i < links.Length; i++)
            {
                if (id == links[i].Item1)
                    toReturn.Add(tiles[(int)links[i].Item2]);
            }
            return toReturn.ToArray();
        }

        public int GetTileId(Tile tile)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                if (tile == tiles[i])
                    return i;
            }
            Debug.LogWarning(tile +" don't exist in this map.");
            return -1;
        }
    }
}