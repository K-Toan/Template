public abstract class PlayerBaseState : EntityBaseState<PlayerState>
{
    protected PlayerController pController;
    protected PlayerInputSystem pInput;
    protected PlayerStateMachine pStateMachine;

    public PlayerBaseState(PlayerController playerController)
    {
        pController = playerController;

        pInput = pController.Input;
        pStateMachine = pController.StateMachine;
    }
}