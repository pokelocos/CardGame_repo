using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MapSystem
{
    [System.Serializable]
    public class Tile
    {
        public State state;
        public Tuple<float,float,float> position;
        public string[] tags;
        
        public Vector3 Position
        {
            get { return new Vector3(position.Item1, position.Item2, position.Item3); }
        }

        public Tile(Tuple<float, float, float> position, State state = State.HIDDEN, string[] tags = null)
        {
            this.position = position;
            this.state = state;
            this.tags = tags;
        }

        public Tile(float x, float y, float z, State state = State.HIDDEN, string[] tags = null)
        {
            this.position = new Tuple<float, float, float>(x, y, z);
            this.state = state;
            this.tags = tags;
        }

    }
}
