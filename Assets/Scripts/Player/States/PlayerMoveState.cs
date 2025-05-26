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
        if (player.Input.Dash && player.CanDash)
        {
            // set state
            player.StateMachine.SetState(PlayerState.Dash);
        }

        // stop moving
        if (player.MoveDir == Vector2.zero)
        {
            player.StateMachine.SetState(PlayerState.Idle);
        }
    }

    public override void FixedUpdate()
    {
        player.Move();
    }
}