
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class IsCoverSpotNode : Node
{
    List<UnitCover> _coversAvailable;
    NavMeshAgent _agent;

    public IsCoverSpotNode(List<UnitCover> coverAvailable, NavMeshAgent agent)
    {
        this._coversAvailable = coverAvailable;
        this._agent = agent;
    }

    public override NodeStat Evaluate()
    {
        return CheckIsCoveredSpot() ? NodeStat.RUNNING : NodeStat.FAILURE;
    }

    bool CheckIsCoveredSpot()
    {
        //Debug.Log(_agent.remainingDistance);
        if (_agent.remainingDistance<=0f)
        {
            
            Transform currrentSpot = _agent.transform;
         
            for (int i = 0; i < _coversAvailable.Count-1; i++)
            {
                Transform[] coverSpot = _coversAvailable[i].GetCoverSpots();
                foreach (var spot in coverSpot)
                {
                    float distance = Vector3.Distance(_agent.transform.position, spot.position);
                    Debug.Log(distance);
                    Debug.Log(i);
                    if (distance<2f)
                    {
                        Debug.Log("IsCoverSpot: Is cover");
                        return true;
                    }
                }
            }
        }
        Debug.Log("IsCoverSpot: Is not cover");
        return false;
    }

  
}
