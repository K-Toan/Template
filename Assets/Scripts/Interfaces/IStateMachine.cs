namespace Template.Interfaces
{
    public interface IStateMachine<State> where State : IBaseState
    {
        void SwitchState(State newState);
    }
}