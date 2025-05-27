
public class PlayerDashAnimation : PlayerBaseAnimation
{
    public PlayerDashAnimation(PlayerController playerController) : base(playerController)
    {

    }

    public override void Enter()
    {
        // play animation
        pAnim.SetTrigger(dashHash);
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        pAnim.SetFloat(speedXHash, pController.DashDir.x);
        pAnim.SetFloat(speedYHash, pController.DashDir.y);
    }
}