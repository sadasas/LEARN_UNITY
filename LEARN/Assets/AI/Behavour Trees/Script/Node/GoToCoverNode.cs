using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToCoverNode : Node
{
    private NavMeshAgent agent;
    private EnemyAI ai;

    public GoToCoverNode(NavMeshAgent agent, EnemyAI ai)
    {
        this.agent = agent;
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        Transform cover = ai.GetBestCover();
        Debug.Log("GO TO CPVER");
        if (cover == null)
        {
            return NodeState.FAILURE;
        }
        float distance = Vector3.Distance(cover.position, agent.transform.position);
        if (distance > 0.2f)
        {
            agent.isStopped = false;
            agent.SetDestination(cover.position);
            ai.SetColor(Color.black);
            return NodeState.RUNNING;
        }
        else
        {
            agent.isStopped = true;
            return NodeState.SUCCES;
        }
    }
}