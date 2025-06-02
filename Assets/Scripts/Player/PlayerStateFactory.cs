using Template.Interfaces;

namespace Template.Characters.Player
{
    public class PlayerStateFactory : IStateFactory<PlayerBaseState>
    {
        private PlayerStateMachine _stateMachine;

        public PlayerStateFactory(PlayerStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public PlayerBaseState Default() => Move;
        public PlayerBaseState Exit() => Move;
        public PlayerBaseState Move => new PlayerMoveState(_stateMachine, this);
        public PlayerBaseState Dash => new PlayerDashState(_stateMachine, this);
        public PlayerBaseState EndDash => new PlayerEndDashState(_stateMachine, this);
    }
}
