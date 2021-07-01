using System.Collections.Generic;

using UnityEngine;

public class Sequence : Node
{
    protected List<Node> nodes = new List<Node>();

    public Sequence(List<Node> nodes)
    {
        this.nodes = nodes;
    }

    public override NodeState Evaluate()
    {
        bool isAnyNodeRunning = false;
        foreach (var node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:
                    Debug.Log("RUNNING");
                    isAnyNodeRunning = true;
                    break;

                case NodeState.SUCCES:
                    Debug.Log("SUCCESS");
                    break;

                case NodeState.FAILURE:
                    Debug.Log("FAILURE");
                    _nodeState = NodeState.FAILURE;
                    return _nodeState;

                default:
                    break;
            }
        }
        _nodeState = isAnyNodeRunning ? NodeState.RUNNING : NodeState.SUCCES;
        return _nodeState;
    }
}