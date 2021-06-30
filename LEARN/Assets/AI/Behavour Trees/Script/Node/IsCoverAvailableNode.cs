using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCoverAvailableNode : Node
{
    private Cover[] availableCover;
    private Transform target;
    private EnemyAI ai;

    public IsCoverAvailableNode(Cover[] availableCover, Transform target, EnemyAI ai)
    {
        this.availableCover = availableCover;
        this.target = target;
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        Transform bestSpot = FindBestCoverSpot();
        ai.SetBestCoverSpot(bestSpot);
        return bestSpot != null ? NodeState.SUCCES : NodeState.FAILURE;
    }

    private Transform FindBestCoverSpot()
    {
        float minAngle = 90;
        Transform bestSpot = null;
        for (int i = 0; i < availableCover.Length; i++)
        {
            Transform bestSpotInCover = FindBestSpotInCover(availableCover[i], ref minAngle);
            if (bestSpotInCover != null)
            {
                bestSpot = bestSpotInCover;
            }
        }

        return bestSpot;
    }

    private Transform FindBestSpotInCover(Cover cover, ref float minAngle)
    {
        Transform[] availableSpot = cover.GetCoverSpots();
        Transform bestSpot = null;
        for (int i = 0; i < availableSpot.Length; i++)
        {
            Vector3 direction = target.position - availableSpot[i].position;
            if (CheckIfCoverIsValid(availableSpot[i]))
            {
                float angle = Vector3.Angle(availableSpot[i].forward, direction);
                if (angle < minAngle)
                {
                    minAngle = angle;
                    bestSpot = availableSpot[i];
                }
            }
        }
        return bestSpot;
    }

    private bool CheckIfCoverIsValid(Transform spot)
    {
        RaycastHit hit;
        Vector3 direction = target.position - spot.position;
        if (Physics.Raycast(spot.position, direction, out hit))
        {
            if (hit.collider.transform != target)
            {
                return true;
            }
        }
        return false;
    }
}