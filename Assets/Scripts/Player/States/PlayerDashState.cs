using UnityEngine;

namespace Template.Characters.Player
{
    public class PlayerDashState : PlayerBaseState
    {
        protected float dashSpeed;
        protected float dashDuration;
        protected Vector2 dashDir;
        protected int speedHash;
        protected int speedXHash;
        protected int speedYHash;

        public PlayerDashState(PlayerStateMachine stateMachine, PlayerStateFactory stateFactory) : base(stateMachine, stateFactory)
        {
            speedXHash = Animator.StringToHash("SpeedX");
            speedYHash = Animator.StringToHash("SpeedY");
        }

        public override void Enter()
        {
            // Initialize Dash state
            Logger.LogInfo("Entering Dash State");
            dashSpeed = stateMachine.Stats.DashSpeed;
            dashDuration = stateMachine.Stats.DashDuration;
            dashDir = stateMachine.Stats.FaceDirection;

            // if (dashDir == Vector2.zero)
            // {
            //     Logger.LogInfo("Dash direction equals vector2 zero.");
            // }

            // Start cooldown
            stateMachine.Stats.StartDashCooldown();
        }

        public override void Exit()
        {
            // Cleanup Dash state
            Logger.LogInfo("Exiting Dash State");
            stateMachine.Rb.linearVelocity = Vector2.zero;
        }

        public override void LogicUpdate()
        {
            // Handle logic for Dash state
            dashDuration -= Time.deltaTime;
        }

        public override void PhysicUpdate()
        {
            // Handle physics for Dash state
            // Perform dash 
            stateMachine.Rb.linearVelocity = dashDir * dashSpeed;
        }

        public override void AnimationUpdate()
        {
            // Handle animation for Dash state
            stateMachine.Animator.Play("Dash");
            stateMachine.Animator.SetFloat(speedXHash, dashDir.x);
            stateMachine.Animator.SetFloat(speedYHash, dashDir.y);
        }

        public override void CheckSwitchState()
        {
            // Check conditions to switch from dash state
            if (dashDuration <= 0)
            {
                // Switch to Move state after dash duration ends
                // stateMachine.SwitchState(stateFactory.EndDash);
                stateMachine.SwitchState(stateFactory.Move);
            }
        }
    }
}