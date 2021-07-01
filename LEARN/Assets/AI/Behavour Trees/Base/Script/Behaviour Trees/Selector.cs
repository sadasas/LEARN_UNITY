using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Selector : Node
{
    protected List<Node> nodes = new List<Node>();

    public Selector(List<Node> nodes)
    {
        this.nodes = nodes;
    }

    public override NodeState Evaluate()
    {
        foreach (var node in nodes)
        {
            Debug.Log("SELECT");
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:
                    _nodeState = NodeState.RUNNING;
                    Debug.Log("RUNNING");
                    return _nodeState;

                case NodeState.SUCCES:
                    _nodeState = NodeState.SUCCES;
                    Debug.Log("SUCCESS");
                    return _nodeState;

                case NodeState.FAILURE:
                    Debug.Log("FAILURE");
                    break;

                default:
                    break;
            }
        }
        _nodeState = NodeState.FAILURE;
        return _nodeState;
    }
}