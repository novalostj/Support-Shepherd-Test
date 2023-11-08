using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace StateMachine
{
    public abstract class TStateHolder<Machine, State, Transition> : ScriptableObject
    {
        [FormerlySerializedAs("_transitions")] public List<Transition> transitions;
        
        public abstract State Initialize(Machine machine);
    }

    public abstract class TStateHandler<Machine, Holder, Transition>
    {
        public List<Transition> _transitions;
        public Machine _machine;
        public Holder _holder;

        public TStateHandler(Machine machine, Holder holder)
        {
            _machine = machine;
            _holder = holder;
        }

        public abstract void StateUpdate();
        public abstract void FixedUpdate();
        public abstract void Destroy();
    }
}