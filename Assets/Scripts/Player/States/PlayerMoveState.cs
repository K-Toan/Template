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

        player.Move();
    }

    public override void FixedUpdate()
    {

    }
}