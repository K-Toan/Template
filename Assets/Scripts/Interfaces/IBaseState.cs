namespace Template.Interfaces
{
    public interface IBaseState
    {
        void Enter();
        void Exit();
        void LogicUpdate();
        void PhysicUpdate();
        void AnimationUpdate();
        void CheckSwitchState();
    }
}