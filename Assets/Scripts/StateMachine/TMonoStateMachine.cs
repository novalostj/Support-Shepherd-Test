using UnityEngine;

namespace StateMachine
{
    public abstract class TMonoStateMachine<StateHolder, State> : MonoBehaviour
    {
        [SerializeField] private StateHolder initialState;
    
        private State _currentState;

        public State CurrentState
        {
            get => _currentState;
            protected set => _currentState = value;
        }
        
        protected virtual StateHolder InitialState => initialState;

        protected virtual void Start() => SetState(InitialState);
        protected abstract void Update();
        protected abstract void FixedUpdate();
        public abstract void SetState(StateHolder stateHolder);
    }
}
