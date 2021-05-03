using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyControl : MonoBehaviour
{
    [SerializeField]
    private Transform[] target;

    private NavMeshAgent navMeshAgent;

    [SerializeField]
    private int setDes;

    public bool walkPointSet;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Patroling();
    }

    private void Patroling()
    {
        if (!walkPointSet) SetWalkPoint();
        if (walkPointSet) navMeshAgent.SetDestination(target[setDes].position);

        float b = navMeshAgent.remainingDistance;
        if (b < 1f) walkPointSet = false;
        Debug.Log(b);
        /*Vector3 distanceWalkPoint = target[setDes].position - transform.position;
        if (distanceWalkPoint.magnitude < 1f) walkPointSet = false;*/
    }

    private void SetWalkPoint()
    {
        int random = Random.Range(0, target.Length);
        setDes = random;
        walkPointSet = true;
    }
}