using MapSystem;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonSystem
{
    public class BehaviourTile : MonoBehaviour
    {
        public List<BehaviourTile> neighbors = new List<BehaviourTile>();
        public Tile tileData;

        public void Initialize(Tile tile)
        {
            this.tileData = tile;
        }

        private void OnDrawGizmos()
        {
            foreach (var neighbor in this.neighbors)
            {
                Gizmos.DrawLine(this.transform.position,neighbor.transform.position);
            }
        }
    }
}