using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StateType
{
    Idle,
    Walk,
    Run,
    Attack
}


public class FSM
{
    public GameObject Owner { get; private set; }

    private Dictionary<StateType, State> states;
    private State currentState;

    public void Initialize (GameObject owner)
    {
        this.Owner = owner;
    }

    public void AddState(StateType newType, State newState)
    {
        states.Add(newType, newState);
        states[newType].Initialize(this);
    }

    public void UpdateState()
    {
        currentState.Update();
    }

    public void ToState(StateType key)
    {
        if (!states.ContainsKey(key))
        {
            return;
        }
        currentState.Exit();
        currentState = states[key];
        currentState.Enter();
    }
}

