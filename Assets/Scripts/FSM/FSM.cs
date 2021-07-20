using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


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
    GameObject player;
    NavMeshAgent navMesh;
    

    private Dictionary<StateType, State> states;
    private State currentState;

    public void Initialize (GameObject owner, GameObject player, NavMeshAgent navMesh)
    {
        this.Owner = owner;
        this.player = player;
        this.navMesh = navMesh;
    }

    public void AddState(StateType newType, State newState)
    {
        states.Add(newType, newState);
        states[newType].Initialize(this, player, navMesh);
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

