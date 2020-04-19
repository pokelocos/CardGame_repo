using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace DungeonSystem
{
    [RequireComponent(typeof(Animator))]
    public class MapCharacterBehaviour : MonoBehaviour
    {
        [HideInInspector]
        public BehaviourTile tile = null;

        private Animator animator;

        public float speed = 1;
        private BehaviourTile to;

        private State state = State.Stay;
        private State lastState = State.Stay;

        public UnityEvent OnStartMove;
        public UnityEvent OnFinishMove;
        public UnityEvent OnStartCombat;

        private void Awake()
        {
            this.animator = this.GetComponent<Animator>();
        }

        private void Update()
        {
            switch(state)
            {
                case State.Stay:
                    // do Nothing!!
                    break;
                case State.Walk:
                    if(lastState != State.Walk)
                    {
                        OnStartMove.Invoke();
                    }
                    var dir = (to.transform.position - this.transform.position).normalized;
                    this.transform.Translate(dir * speed * Time.deltaTime);
                    if(Vector3.Distance(to.transform.position,this.transform.position) < 0.01f)
                    {
                        state = State.Stay;
                        tile = to;
                        OnFinishMove.Invoke();
                    }
                    break;
            }

            lastState = state;
        }


        public void Move(BehaviourTile to)
        {
            state = State.Walk;
            this.animator.SetBool("Move",true);
            this.to = to;
        }

    }

    public enum State
    {
        Stay,
        Walk
    }
}
