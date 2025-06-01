using UnityEngine;
using Template.Interfaces;

namespace Template.Characters.Player
{
    public abstract class PlayerBaseState : IBaseState
    {
        protected PlayerStateMachine stateMachine;
        protected PlayerStateFactory stateFactory;

        public PlayerBaseState(PlayerStateMachine stateMachine, PlayerStateFactory stateFactory)
        {
            this.stateMachine = stateMachine;
            this.stateFactory = stateFactory;
        }

        public abstract void Enter();
        public abstract void Exit();

        public abstract void LogicUpdate();
        public abstract void AnimationUpdate();
        public abstract void PhysicUpdate();

        public abstract void CheckSwitchState();
    }
}