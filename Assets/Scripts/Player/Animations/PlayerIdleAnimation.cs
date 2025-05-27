public class PlayerIdleAnimation : PlayerBaseAnimation
{
    public PlayerIdleAnimation(PlayerController playerController) : base(playerController)
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
        pAnim.SetFloat(speedXHash, pController.LastMoveDir.x);
        pAnim.SetFloat(speedYHash, pController.LastMoveDir.y);
        pAnim.SetFloat(speedHash, pController.CurrentSpeed);
    }
}