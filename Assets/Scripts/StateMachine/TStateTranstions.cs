using System;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    [Serializable]
    public abstract class TStateTransitions<Machine, StateHolder, EventEnum>
    {
        public StateHolder state;
        public List<EventEnum> eventsToListen;
        
        protected Machine _machine;

        public virtual void Start(Machine machine)
        {
            _machine = machine;
        }

        public abstract void Stop();
        public abstract void SetState();
    }
}