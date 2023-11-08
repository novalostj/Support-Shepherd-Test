using UnityEngine;

namespace Player.StateMachine.States
{
    [CreateAssetMenu(menuName = "Player/States/Move")]
    public class PlayerMoveHolder : PlayerStateHolder
    {
        public float speed = 4;
        
        public override PlayerStateHandler Initialize(PlayerMonoStateMachine machine)
        {
            return new PlayerMoveHandler(machine, this);
        }
    }

    public class PlayerMoveHandler : PlayerStateHandler
    {
        protected PlayerMoveHolder _moveHolder;
        protected Transform _cameraTransform;
        
        public PlayerMoveHandler(PlayerMonoStateMachine machine, PlayerMoveHolder holder) : base(machine, holder)
        {
            _moveHolder = holder;
            _cameraTransform = Camera.main.transform;
        }


        public override void StateUpdate()
        {
            base.StateUpdate();
            Vector2 playerMovementInput = _machine.PlayerInput.MovementInput;
            Vector3 movementDirection = new Vector3(playerMovementInput.x, 0, playerMovementInput.y);
            movementDirection = _cameraTransform.forward * movementDirection.z + _cameraTransform.right * movementDirection.x;
            movementDirection.y = 0;
            CharacterController.Move(movementDirection * (Time.deltaTime * _moveHolder.speed));
        }

        public override void FixedUpdate()
        {
            
        }

        public override void Destroy()
        {
        }

        protected void Move(Vector2 direction)
        {
            
        }
    }
}