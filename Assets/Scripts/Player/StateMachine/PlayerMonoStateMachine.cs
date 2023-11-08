using General;
using Player.StateMachine.States;
using StateMachine;
using UnityEngine;

namespace Player.StateMachine
{
    public class PlayerMonoStateMachine : TMonoStateMachine<PlayerStateHolder, PlayerStateHandler>, IPlayer
    {
        private CharacterController _characterController;
        private PlayerInput _playerInput;

        public CharacterController CharacterController => _characterController != null
            ? _characterController
            : _characterController = GetComponent<CharacterController>();
        public PlayerInput PlayerInput => _playerInput != null
            ? _playerInput
            : _playerInput = GetComponent<PlayerInput>();
        
        protected override void Update()
        {
            CurrentState?.StateUpdate();
        }

        protected override void FixedUpdate()
        {
            CurrentState?.FixedUpdate();
        }

        public override void SetState(PlayerStateHolder stateHolder)
        {
            if (stateHolder == null)
            {
                Debug.LogError("State is null, cancelling!");
                return;
            }

            Debug.Log(CurrentState != null
                ? $"Starting State {stateHolder.name}"
                : $"{gameObject.name}: {CurrentState?._holder.name} | {stateHolder.name}");

            CurrentState?.Destroy();
            CurrentState = stateHolder.Initialize(this);
        }

        public void TakeDamage()
        {
            Destroy(gameObject);
        }
    }
}