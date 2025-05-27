using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityStateMachine<EState> : MonoBehaviour where EState : Enum
{
    protected EntityBaseState<EState> currentState;
    protected Dictionary<EState, EntityBaseState<EState>> states = new Dictionary<EState, EntityBaseState<EState>>();

    public virtual void SetState(EState key)
    {
        currentState?.Exit();
        currentState = states[key];
        currentState?.Enter();
    }

    public virtual void Update()
    {
        currentState?.Update();
    }

    public virtual void FixedUpdate()
    {
        currentState?.FixedUpdate();
    }
}