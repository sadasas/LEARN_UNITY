using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Inventer : Node
{
    protected Node _node;

    public Inventer(Node _node)
    {
        this._node = _node;
    }

    public override NodeState Evaluate()
    {
        switch (_node.Evaluate())
        {
            case NodeState.RUNNING:
                _nodeState = NodeState.RUNNING;
                break;

            case NodeState.SUCCES:
                _nodeState = NodeState.FAILURE;
                break;

            case NodeState.FAILURE:
                _nodeState = NodeState.SUCCES;
                break;

            default:
                break;
        }
        return _nodeState;
    }
}