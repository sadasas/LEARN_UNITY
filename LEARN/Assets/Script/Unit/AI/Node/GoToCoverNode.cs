using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToCoverNode : Node
{
    NavMeshAgent _agent;
    AIBrain _brain;

    public GoToCoverNode(NavMeshAgent agent, AIBrain brain)
    {
        this._agent = agent;
        this._brain = brain;
    }
    public override NodeStat Evaluate()
    {
        return GoToCoverSpot() != null ? NodeStat.RUNNING : NodeStat.FAILURE;
    }

    Transform GoToCoverSpot()
    {
        Transform spot = null;
       
        if(_brain.GetBestCoverSpot()!=null)
        {
            if (_agent.hasPath)
            { // Debug.Log("GOTOCOVER NODE: runnn");
                _agent.ResetPath();
            }
            spot = _brain.GetBestCoverSpot();
            _agent.stoppingDistance = 0f;
            
            _agent.SetDestination(spot.position);

        }

        return spot;
    }




}
