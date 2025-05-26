using System.Collections.Generic;

public class PlayerStateMachine : EntityStateMachine<PlayerState>
{
    protected PlayerController player;

    public void Initialize(PlayerController player)
    {
        this.player = player;

        states = new Dictionary<PlayerState, EntityBaseState<PlayerState>>
        {
            { PlayerState.Idle, new PlayerIdleState(player) },
            { PlayerState.Run, new PlayerMoveState(player) },
            { PlayerState.Dash, new PlayerDashState(player) },
            { PlayerState.Attack, new PlayerAttackState(player) },
        };

        SetDefaultState();
    }

    public void SetDefaultState()
    {
        SetState(PlayerState.Idle);
    }
}