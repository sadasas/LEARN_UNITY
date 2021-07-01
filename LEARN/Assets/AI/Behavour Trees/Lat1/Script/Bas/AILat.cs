using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILat : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    private Nodelat node;

    private void Start()
    {
        SetContructBehaviourTree();
    }

    private void SetContructBehaviourTree()
    {
        IdleNode idleNode = new IdleNode(playerTransform, this.transform);
        RunNode runNode = new RunNode(playerTransform, this.transform);
        node = new Sequencelat(new List<Nodelat> { idleNode, runNode });
    }

    private void Update()
    {
        node.Perilaku();
    }
}