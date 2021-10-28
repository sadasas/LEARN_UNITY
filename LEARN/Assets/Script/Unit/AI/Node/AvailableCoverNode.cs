
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AvailableCoverNode : Node
{
   
    List<UnitCover> _availableCovers;
    AIBrain _brain;
   public Transform target { get; set; }
   

    public AvailableCoverNode(List<UnitCover> availableCovers, AIBrain brain)
    {
        this._brain = brain;
      
        this._availableCovers = availableCovers;
     
    }

    public override NodeStat Evaluate()
    {
        Transform bestSpot = FindBestCoverSpot();
        _brain.SetBestCoverSpot(bestSpot);
      
        return bestSpot != null ? NodeStat.RUNNING : NodeStat.FAILURE;
    }

    Transform FindBestCoverSpot()
    {
        if(_brain.GetBestCoverSpot()!=null)
        {
            if(CheckIsValidSpot(_brain.GetBestCoverSpot()))
            {
                return _brain.GetBestCoverSpot();
            }
        }


        Transform bestSpot = null;
        float minAngle = 90;
        Debug.Log(_availableCovers.Count);
        for (int i = 0; i < _availableCovers.Count-1; i++)
        {
            Transform bestSpotInCovers = FindBestSpotInCover(_availableCovers[i],ref minAngle);
            if(bestSpotInCovers!=null)
            {
                Debug.Log("AVAILABLECOVER: set cover");
                bestSpot = bestSpotInCovers;
            }
        }

        return bestSpot;
    }

    Transform FindBestSpotInCover(UnitCover cover, ref float minAngle)
    {
        Transform[] availableSpot = cover.GetCoverSpots();
        Debug.Log(availableSpot.Length);
        Transform bestSpot = null;
        Debug.Log(target);
        for (int i = 0; i < availableSpot.Length; i++)
        {
            Vector3 direction = target.position - availableSpot[i].position;
            if(CheckIsValidSpot(availableSpot[i]))
            {
                float angle = Vector3.Angle(availableSpot[i].forward, direction);
                Debug.Log(angle);
                if (angle > minAngle)
                {
                    Debug.Log("AVAILABLECOVER: Set spot");
                    minAngle = angle;
                    bestSpot = availableSpot[i];
                }
            }
           
        }

        return bestSpot;
    }

    bool CheckIsValidSpot(Transform spot)
    {
        RaycastHit hit;
        Vector3 direction = target.position - spot.position;
        if(Physics.Raycast(spot.position,direction,out hit))
        {
            if(hit.collider.transform!=target)
            {
                Debug.Log("AVAILABLECOVER: spot valid");
                return true;
            }
        }
        Debug.Log("AVAILABLECOVER: spot not  valid");
        return false;
    }

}
