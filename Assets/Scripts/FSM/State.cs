using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected FSM owner;

    public void Initialize (FSM owner)
    {
        this.owner = owner;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}
