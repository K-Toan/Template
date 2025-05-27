using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerController player) : base(player)
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

        // stop moving
        if (pController.MoveDir == Vector2.zero)
        {
            pStateMachine.SetState(PlayerState.Idle);
        }
    }

    public override void FixedUpdate()
    {
        pController.Move();
    }
}