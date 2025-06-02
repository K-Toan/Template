using UnityEngine;

namespace Template.Characters.Player
{
    public class PlayerMoveState : PlayerBaseState
    {
        protected float moveSpeed;
        protected float currentSpeed;
        protected float acceleration;
        protected float deceleration;
        protected Vector2 moveDirection;
        protected Vector2 lastMoveDirection;
        protected int speedHash;
        protected int speedXHash;
        protected int speedYHash;

        public PlayerMoveState(PlayerStateMachine stateMachine, PlayerStateFactory stateFactory) : base(stateMachine, stateFactory)
        {
            speedHash = Animator.StringToHash("CurrentSpeed");
            speedXHash = Animator.StringToHash("SpeedX");
            speedYHash = Animator.StringToHash("SpeedY");
        }

        public override void Enter()
        {
            // Initialize move state
            Logger.LogInfo("Entering Move State");

            // Set initial values
            moveSpeed = stateMachine.Stats.MoveSpeed;
            acceleration = stateMachine.Stats.Acceleration;
            deceleration = stateMachine.Stats.Deceleration;

            // Disable hurtbox
            // ...
        }

        public override void Exit()
        {
            // Cleanup move state
            Logger.LogInfo("Exiting Move State");
        }

        public override void LogicUpdate()
        {
            // Handle logic for move state
            moveDirection = stateMachine.Input.Move.normalized;

            if (moveDirection != Vector2.zero)
                lastMoveDirection = moveDirection;

            currentSpeed = stateMachine.Rb.linearVelocity.magnitude / moveSpeed;
        }

        public override void PhysicUpdate()
        {
            // Handle physics for move state
            float mult = acceleration;

            // Apply movement based 
            if (moveDirection == Vector2.zero)
                mult = deceleration;
            
            stateMachine.Rb.linearVelocity = Vector2.Lerp(
                stateMachine.Rb.linearVelocity,
                moveDirection * moveSpeed,
                mult * Time.fixedDeltaTime
            );
        }

        public override void AnimationUpdate()
        {
            // Set animation based on speed
            if(currentSpeed <= 0.1f)
                stateMachine.Animator.Play("Idle");
            else if(currentSpeed >= 0.1f && currentSpeed < 0.4f)
                stateMachine.Animator.Play("Walk");
            else
                stateMachine.Animator.Play("Run");

            // Handle animation for move state
            stateMachine.Animator.SetFloat(speedHash, currentSpeed);
            stateMachine.Animator.SetFloat(speedXHash, lastMoveDirection.x);
            stateMachine.Animator.SetFloat(speedYHash, lastMoveDirection.y);
        }

        public override void CheckSwitchState()
        {
            // Check conditions to switch from move state

            if (stateMachine.Input.Dash && stateMachine.Stats.CanDash)
            {
                stateMachine.Stats.FaceDirection = lastMoveDirection;
                stateMachine.SwitchState(stateFactory.Dash);
            }
        }
    }
}