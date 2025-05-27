using UnityEngine;

public abstract class PlayerBaseAnimation : EntityBaseState<PlayerAnimation>
{
    // protected Vector2 aimDir;
    // protected Vector2 dashDir;
    // protected Vector2 attackDir;

    protected Animator pAnim;
    protected PlayerController pController;
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

    public PlayerBaseAnimation(PlayerController playerController)
    {
        pController = playerController;

        pAnim = pController.Anim;
        pInput = pController.Input;
        pStateMachine = pController.StateMachine;

        AssignAnimationHashes();
    }

    public override void Enter()
    {
    }

    public override void Update()
    {
    }

    public override void FixedUpdate()
    {
    }

    public override void Exit()
    {

    }

    protected float GetCurrentAnimationDuration()
    {
        // return pAnim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        return pAnim.GetCurrentAnimatorStateInfo(0).length;
    }
}