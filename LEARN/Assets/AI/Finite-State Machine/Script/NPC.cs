using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(FiniteStateMachine))]
public class NPC : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private FiniteStateMachine finiteStateMachine;

    private void Awake()
    {
        finiteStateMachine = GetComponent<FiniteStateMachine>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
}