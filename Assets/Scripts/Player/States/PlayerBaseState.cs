using UnityEngine;

public abstract class PlayerBaseState : EntityBaseState<PlayerState>
{
    protected PlayerController pController;
    protected Animator pAnimator;
    protected SpriteRenderer pSpriteRenderer;
    protected PlayerInputSystem pInput;
    protected PlayerStateMachine pStateMachine;

    protected int speedHash;
    protected int speedXHash;
    protected int speedYHash;
    protected int lookXHash;
    protected int lookYHash;
    protected int dashHash;
    protected int attackHash;

    private void AssignAnimationHashes()
    {
        speedHash = Animator.StringToHash("CurrentSpeed");
        speedXHash = Animator.StringToHash("SpeedX");
        speedYHash = Animator.StringToHash("SpeedY");
        lookXHash = Animator.StringToHash("LookX");
        lookYHash = Animator.StringToHash("LookY");
        dashHash = Animator.StringToHash("Dash");
        attackHash = Animator.StringToHash("Attack");
    }

    public PlayerBaseState(PlayerController playerController)
    {
        pController = playerController;

        pAnimator = pController.Anim;
        pInput = pController.Input;
        pStateMachine = pController.StateMachine;
        pSpriteRenderer = pController.SprtRenderer;

        AssignAnimationHashes();
    }

    protected float GetCurrentAnimationDuration()
    {
        // return pAnim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        return pAnimator.GetCurrentAnimatorStateInfo(0).length;
    }

}