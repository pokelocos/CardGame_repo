using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DungeonSystem
{
    public class CharacterContoller : MonoBehaviour
    {
        public MapCharacterBehaviour character;

        public void Start()
        {
            character.OnStartMove.AddListener(() => this.enabled = false);
            character.OnFinishMove.AddListener(() => this.enabled = true);
        }

        public void Update()
        {
            if (Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f)
            {
                var dir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0).normalized;
                float directionError = float.MaxValue;
                BehaviourTile to = null;
                foreach (var neighbor in character.tile.neighbors)
                {
                    var dirNeighbor = Vector3.Normalize(neighbor.transform.position - character.tile.transform.position);
                    var dirError = Vector3.Distance(dirNeighbor, dir.normalized);
                    if (Vector3.Distance(dirNeighbor, dir.normalized) < directionError)
                    {
                        directionError = dirError;
                        to = neighbor;
                    }
                }

                if (to != null && directionError < 0.4f)
                {                    
                    character.Move(to);
                }
            }
        }
    }
}
