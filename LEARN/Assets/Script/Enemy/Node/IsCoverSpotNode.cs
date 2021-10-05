
using UnityEngine;
using UnityEngine.AI;

public class IsCoverSpotNode : Node
{
    UnitCover[] _coversAvailable;
    NavMeshAgent _agent;

    public IsCoverSpotNode(UnitCover[] coverAvailable, NavMeshAgent agent)
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
        Debug.Log(_agent.remainingDistance);
        if (_agent.remainingDistance<=0f)
        {
            
            Transform currrentSpot = _agent.transform;
         
            for (int i = 0; i < _coversAvailable.Length; i++)
            {
                Transform[] coverSpot = _coversAvailable[i].GetCoverSpots();
                foreach (var spot in coverSpot)
                {
                    float distance = Vector3.Distance(currrentSpot.position, spot.position);
                    Debug.Log(distance);
                    if (distance<1f)
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
