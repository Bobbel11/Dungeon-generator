using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class State
{
    protected FSM owner;
    protected GameObject player;
    protected NavMeshAgent navMesh;

    public void Initialize (FSM owner, GameObject player, NavMeshAgent navMesh)
    {
        this.owner = owner;
        this.player = player;
        this.navMesh = navMesh;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}
