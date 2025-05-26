using System.Collections;
using UnityEngine;

public class PlayerDashState : PlayerBaseState
{
    private float _dashTime = 0.0f;

    public PlayerDashState(PlayerController player) : base(player)
    {
    }

    public override void Enter()
    {
        // set timer
        _dashTime = player.DashDuration;
        player.StartDashCooldownCoroutine();

        // set dash direction
        player.DashDir = player.LastMoveDir;

        // disable hurtbox
        // ...
    }

    public override void Exit()
    {
        // enable hurtbox
        // ...
    }

    public override void Update()
    {
        // perform dash
        if (_dashTime > 0.0f)
        {
            _dashTime -= Time.deltaTime;
        }
        // set state to idle
        else
        {
            // reset dash time
            _dashTime = 0.0f;

            // reset state
            player.StateMachine.SetState(PlayerState.Idle);
        }
    }

    public override void FixedUpdate()
    {
        if (_dashTime > 0.0f)
        {
            player.Dash();
        }
    }
}