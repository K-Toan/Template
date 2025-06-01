using UnityEngine;

namespace Template.Characters.Player
{
    public class PlayerDashState : PlayerBaseState
    {
        protected float dashDuration;
        protected float dashSpeed;
        protected Vector2 dashDir;
        protected int speedHash;
        protected int speedXHash;
        protected int speedYHash;

        public PlayerDashState(PlayerStateMachine stateMachine, PlayerStateFactory stateFactory) : base(stateMachine, stateFactory)
        {
            speedHash = Animator.StringToHash("CurrentSpeed");
            speedXHash = Animator.StringToHash("SpeedX");
            speedYHash = Animator.StringToHash("SpeedY");
        }

        public override void Enter()
        {
            // Initialize Dash state
            Logger.LogInfo("Entering Dash State");

            stateMachine.Animator.Play("Dash");
        }

        public override void Exit()
        {
            // Cleanup Dash state
            Logger.LogInfo("Exiting Dash State");
        }

        public override void LogicUpdate()
        {
            // Handle logic for Dash state
            
        }

        public override void PhysicUpdate()
        {
            // Handle physics for Dash state
            // Perform dash 

        }

        public override void AnimationUpdate()
        {
            // Handle animation for Dash state
            // stateMachine.Animator.SetFloat(speedHash, 0);
            // stateMachine.Animator.SetFloat(speedXHash, stateMachine.Stats.LastMoveDir.x);
            // stateMachine.Animator.SetFloat(speedYHash, stateMachine.Stats.LastMoveDir.y);
        }

        public override void CheckSwitchState()
        {
            // Check conditions to switch from Dash state

            if (stateMachine.Input.Dash && stateMachine.Stats.CanDash && stateMachine.Stats.DashCooldownDurationLeft <= 0.0f)
            {
                stateMachine.SwitchState(stateFactory.Dash);
            }
        }
    }
}