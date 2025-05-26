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
        if (player.Input.Dash && player.CanDash)
        {
            // set state
            player.StateMachine.SetState(PlayerState.Dash);
        }

        // move
        if (player.MoveDir != Vector2.zero)
        {
            // set state to run
            player.StateMachine.SetState(PlayerState.Run);
        }

        // do nothing but stand still
        player.Move();
    }

    public override void FixedUpdate()
    {
    }
}