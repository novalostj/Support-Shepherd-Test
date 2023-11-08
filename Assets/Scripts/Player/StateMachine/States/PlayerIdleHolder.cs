using UnityEngine;

namespace Player.StateMachine.States
{
    [CreateAssetMenu(menuName = "Player/States/Idle")]
    public class PlayerIdleHolder : PlayerStateHolder
    {
        public override PlayerStateHandler Initialize(PlayerMonoStateMachine machine)
        {
            return new PlayerIdleHandler(machine, this);
        }
    }

    public class PlayerIdleHandler : PlayerStateHandler
    {
        public PlayerIdleHandler(PlayerMonoStateMachine machine, PlayerIdleHolder holder) : base(machine, holder)
        {
        }

        public override void FixedUpdate()
        {
        }

        public override void Destroy()
        {
        }
    }
}