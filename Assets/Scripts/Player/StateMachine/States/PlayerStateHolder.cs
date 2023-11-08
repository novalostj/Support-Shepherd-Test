using System;
using System.Collections;
using System.Collections.Generic;
using StateMachine;
using UnityEngine;

namespace Player.StateMachine.States
{
    public abstract class PlayerStateHolder : TStateHolder<PlayerMonoStateMachine, PlayerStateHandler, PlayerStateTransitions>
    {
        public float gravityMultiplier = 1;
    }

    public abstract class PlayerStateHandler : TStateHandler<PlayerMonoStateMachine, PlayerStateHolder, PlayerStateTransitions>
    {
        protected CharacterController CharacterController => _machine.CharacterController;
        
        public PlayerStateHandler(PlayerMonoStateMachine machine, PlayerStateHolder holder) : base(machine, holder)
        {
            _transitions = new List<PlayerStateTransitions>();
            holder.transitions.ForEach(item =>
            {
                var newItem = new PlayerStateTransitions()
                {
                    state = item.state,
                    conditionals = new PlayerStateTransitionConditionals(item.conditionals)
                };
                _transitions.Add(newItem);
                newItem.Start(machine);
            });
        }

        public override void StateUpdate()
        {
            CharacterController.Move(Physics.gravity * (Time.deltaTime * _holder.gravityMultiplier));
        }

        public override void Destroy()
        {
            _transitions.ForEach(item => item.Stop());
        }
    }

    [Serializable]
    public class PlayerStateTransitions : TStateTransitions<PlayerMonoStateMachine, PlayerStateHolder, PlayerEvents>
    {
        public PlayerStateTransitionConditionals conditionals;

        private Coroutine _conditionalsRoutine;
        
        public override void Start(PlayerMonoStateMachine machine)
        {
            base.Start(machine);
            _conditionalsRoutine = machine.StartCoroutine(CheckConditionals());
        }

        public override void Stop()
        {
            _machine.StopCoroutine(_conditionalsRoutine);
        }

        public override void SetState()
        {
            _machine.SetState(state);
        }

        public IEnumerator CheckConditionals()
        {
            yield return new WaitUntil(() => conditionals.ConditionIsMet(_machine));
            SetState();
        }
    }

    [Serializable]
    public class PlayerStateTransitionConditionals
    {
        public ConditionalBool isHoldingMoveInput;
        public ConditionalBool isHoldingLShift;
        
        public bool ConditionIsMet(PlayerMonoStateMachine machine)
        {
            return IsMoving() && IsHoldingLeftShift();
            
            bool IsMoving()
            {
                return StateConditionals.ConditionalBoolCheck(isHoldingMoveInput,
                    () => machine.PlayerInput.IsHoldingControl);
            }

            bool IsHoldingLeftShift()
            {
                return StateConditionals.ConditionalBoolCheck(isHoldingLShift,
                    () => machine.PlayerInput.IsHoldingShift);
            }
        }

        public PlayerStateTransitionConditionals(PlayerStateTransitionConditionals conditional)
        {
            isHoldingMoveInput = conditional.isHoldingMoveInput;
            isHoldingLShift = conditional.isHoldingLShift;
        }
    }

    public enum PlayerEvents
    {
        
    }
}