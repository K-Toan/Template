using UnityEngine;

namespace Template.Characters.Player
{
    public class PlayerEndDashState : PlayerBaseState
    {
        protected float endDashDuration;
        protected Vector2 dashDir;

        public PlayerEndDashState(PlayerStateMachine stateMachine, PlayerStateFactory stateFactory) : base(stateMachine, stateFactory)
        {
            // speedXHash = Animator.StringToHash("SpeedX");
            // speedYHash = Animator.StringToHash("SpeedY");
        }

        public override void Enter()
        {
            // Initialize Dash state
            Logger.LogInfo("Entering End Dash State");
            dashDir = stateMachine.Stats.FaceDirection;

            // Set animation
            stateMachine.Animator.Play("EndDash");

            AnimatorStateInfo stateInfo = stateMachine.Animator.GetCurrentAnimatorStateInfo(0);
            endDashDuration = stateInfo.length * stateInfo.normalizedTime;

            Logger.LogInfo($"End Dash Duration: {endDashDuration}");
        }

        public override void Exit()
        {
            // Cleanup Dash state
            Logger.LogInfo("Exiting End Dash State");
        }

        public override void LogicUpdate()
        {
            // Handle logic for Dash state
            // endDashDuration -= Time.deltaTime;
        }

        public override void PhysicUpdate()
        {
            // Handle physics for Dash state
            // Perform dash 
            // stateMachine.Rb.linearVelocity = dashDir * dashSpeed;
        }

        public override void AnimationUpdate()
        {
            // Handle animation for Dash state
            // stateMachine.Animator.Play("Dash");

        }

        public override void CheckSwitchState()
        {
            // Check conditions to switch from dash state
            if (endDashDuration <= 0)
            {
                // Switch to Move state after dash duration ends
                stateMachine.SwitchState(stateFactory.Move);
            }
        }
    }
}