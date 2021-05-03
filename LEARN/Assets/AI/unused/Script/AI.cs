using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private NavMeshAgent NavMeshAgent;

    private void Start()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        SetDestination();
    }

    private void SetDestination()
    {
        NavMeshAgent.SetDestination(target.transform.position);
    }
}