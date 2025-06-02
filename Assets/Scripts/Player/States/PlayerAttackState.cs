using UnityEngine;

namespace Template.Characters.Player
{
    public class PlayerAttackState : PlayerBaseState
    {
        
        protected Vector2 attackDir;
        protected int speedHash;
        protected int speedXHash;
        protected int speedYHash;

        public PlayerAttackState(PlayerStateMachine stateMachine, PlayerStateFactory stateFactory) : base(stateMachine, stateFactory)
        {
            speedXHash = Animator.StringToHash("SpeedX");
            speedYHash = Animator.StringToHash("SpeedY");
        }

        public override void Enter()
        {
            // Initialize attack state
            attackDir = stateMachine.Stats.FaceDirection;
        }

        public override void Exit()
        {
            // Cleanup attack state
            Logger.LogInfo("Exiting Attack State");
        }

        public override void LogicUpdate()
        {
            // Handle logic for attack state
        }

        public override void PhysicUpdate()
        {
            // Handle physics for attack state
            // Perform Attack 
        }

        public override void AnimationUpdate()
        {
            // Handle animation for attack state
        }

        public override void CheckSwitchState()
        {
            // Check conditions to switch from attack state

        }
    }
}