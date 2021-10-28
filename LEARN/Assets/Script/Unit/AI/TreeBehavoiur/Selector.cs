
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    List<Node> _nodes = new List<Node>();
    
    public Selector (List<Node> nodes)
    {
        this._nodes = nodes;
    }

    public override NodeStat Evaluate()
    {
        foreach (var node in _nodes)
        {
            switch (node.Evaluate())        
            {
                case NodeStat.RUNNING:
                  Debug.Log("Running");
                    return currentStat = NodeStat.RUNNING;
                case NodeStat.SUCCESS:
                     Debug.Log("Succes");
                    return currentStat = NodeStat.SUCCESS;
                case NodeStat.FAILURE:
                  Debug.Log("Failure");
                    break;
            }
        }
        return currentStat = NodeStat.FAILURE;
    }
}
