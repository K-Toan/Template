using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStateMachine : EntityStateMachine<PlayerState>
{
    public bool CanDash = true;
    protected PlayerController pController;

    public void Initialize(PlayerController playerController)
    {
        pController = playerController;

        states = new Dictionary<PlayerState, EntityBaseState<PlayerState>>
        {
            { PlayerState.Idle, new PlayerIdleState(pController) },
            { PlayerState.Run, new PlayerMoveState(pController) },
            { PlayerState.Dash, new PlayerDashState(pController) },
            { PlayerState.Attack, new PlayerAttackState(pController) },
        };

        SetDefaultState();
    }

    public void SetDefaultState()
    {
        SetState(PlayerState.Idle);
    }

    public void StartDashCooldownCoroutine()
    {
        StartCoroutine(DashCooldownCoroutine());

        IEnumerator DashCooldownCoroutine()
        {
            CanDash = false;
            yield return new WaitForSeconds(1.0f);
            CanDash = true;
        }
    }
}