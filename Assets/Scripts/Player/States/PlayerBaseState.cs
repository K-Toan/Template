public abstract class PlayerBaseState : EntityBaseState<PlayerState>
{
    protected PlayerController player;

    public PlayerBaseState(PlayerController player)
    {
        this.player = player;
    }
}