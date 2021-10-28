using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventor : Node
{
    List<Node> nodes = new List<Node>();

    public Inventor(List<Node> node)
    {
        this.nodes = node;
    }
    public override NodeStat Evaluate()
    {
        foreach (var node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeStat.RUNNING:
                    break;
                case NodeStat.SUCCESS:
                    return currentStat = NodeStat.SUCCESS;

                case NodeStat.FAILURE:
                    break;
             
            }
        }

        return currentStat = NodeStat.FAILURE;
    }
}
