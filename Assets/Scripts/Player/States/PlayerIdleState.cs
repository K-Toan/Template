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
        if (pInput.Dash && pController.CanDash)
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
    }

    public override void FixedUpdate()
    {
        // do nothing but stand still
        pController.StopMoving();
    }
}