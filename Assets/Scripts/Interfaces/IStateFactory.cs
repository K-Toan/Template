namespace Template.Interfaces
{
    public interface IStateFactory<State> where State : IBaseState
    {
        State Default();
    }
}