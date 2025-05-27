using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityStateMachine<EState> : MonoBehaviour where EState : Enum
{
    protected EntityBaseState<EState> defaultState;
    protected EntityBaseState<EState> currentState;
    protected Dictionary<EState, EntityBaseState<EState>> states = new Dictionary<EState, EntityBaseState<EState>>();
    // private bool isWaiting = false;

    public virtual void SetState(EState key)
    {
        currentState?.Exit();
        currentState = states[key];
        currentState?.Enter();
    }

    public virtual void Awake()
    {

    }

    public virtual void Update()
    {
        currentState?.Update();
    }

    public virtual void FixedUpdate()
    {
        currentState?.FixedUpdate();
    }

    private IEnumerator Wait(float seconds)
    {
        // isWaiting = true;
        yield return new WaitForSeconds(seconds);
        // isWaiting = false;
    }
}