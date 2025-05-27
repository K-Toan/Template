using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSystem : EntityStateMachine<PlayerAnimation>
{
    protected Animator pAnim;
    protected SpriteRenderer pSprite;
    protected PlayerController pController;

    // protected int speedHash;
    // protected int speedXHash;
    // protected int speedYHash;
    // protected int lookXHash;
    // protected int lookYHash;
    // protected int dashHash;
    // protected int attackHash;

    public void Initialize(PlayerController playerController)
    {
        pController = playerController;

        pAnim = pController.Anim;
        pSprite = pController.SprtRenderer;

        states = new Dictionary<PlayerAnimation, EntityBaseState<PlayerAnimation>>
        {
            { PlayerAnimation.Idle, new PlayerIdleAnimation(pController) },
            { PlayerAnimation.Run, new PlayerMoveAnimation(pController) },
            { PlayerAnimation.Dash, new PlayerDashAnimation(pController) },
            // { PlayerAnimation.Attack, new PlayerAttackAnimation(pController) },
        };

        defaultState = states[PlayerAnimation.Idle];

        SetState(PlayerAnimation.Idle);
    }

    public override void Update()
    {
        // pAnim.SetFloat(lookXHash, pController.LastMoveDir.x);
        // pAnim.SetFloat(lookYHash, pController.LastMoveDir.y);
        // pAnim.SetFloat(speedXHash, pController.LastMoveDir.x);
        // pAnim.SetFloat(speedYHash, pController.LastMoveDir.y);
        // pAnim.SetFloat(speedHash, pController.CurrentSpeed);

        currentState?.Update();
        HandleFlipX();
    }

    protected void HandleFlipX()
    {
        if (pController.LastMoveDir.x > 0)
        {
            pSprite.flipX = false;
        }
        else if (pController.LastMoveDir.x < 0)
        {
            pSprite.flipX = true;
        }
    }
}