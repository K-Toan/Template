using System;

public abstract class EntityBaseState<EState> where EState : Enum
{
    public abstract void Enter();
    public abstract void Update();
    public abstract void FixedUpdate();
    public abstract void Exit();
}