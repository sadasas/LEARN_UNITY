using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCover : MonoBehaviour
{
    [SerializeField] private Transform[] coverSpots;

    public Transform[] GetCoverSpots()
    {
        return coverSpots;
    }
}
