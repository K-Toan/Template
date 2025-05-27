using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerController player) : base(player)
    {
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        // primary fire

        // secondary fire

        // dash
        if (pInput.Dash && pStateMachine.CanDash)
        {
            // set state
            pStateMachine.SetState(PlayerState.Dash);
        }

        // move
        if (pController.MoveDir != Vector2.zero)
        {
            // set state to run
            pStateMachine.SetState(PlayerState.Run);
        }

        // set animation
        pAnimator.SetFloat(speedXHash, pController.LastMoveDir.x);
        pAnimator.SetFloat(speedYHash, pController.LastMoveDir.y);
        pAnimator.SetFloat(speedHash, pController.CurrentSpeed);
    }

    public override void FixedUpdate()
    {
        // do nothing but stand still
        pController.StopMoving();
    }
}