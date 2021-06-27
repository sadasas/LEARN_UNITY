using FSM.FSMCode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FSM.NPCCode
{
    [RequireComponent(typeof(NavMeshAgent), typeof(FiniteStateMachine))]
    public class NPC : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;
        private FiniteStateMachine finiteStateMachine;

        public Transform[] patrolPoint;

        private void Awake()
        {
            finiteStateMachine = GetComponent<FiniteStateMachine>();
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
    }
}