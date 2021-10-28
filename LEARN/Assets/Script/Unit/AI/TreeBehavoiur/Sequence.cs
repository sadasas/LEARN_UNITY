
using System.Collections.Generic;
using UnityEngine;


public class Sequence :Node
{
    List<Node> nodes = new List<Node>();
    

    public Sequence(List<Node> nodes)
    {
        this.nodes = nodes;
    }

    public override NodeStat Evaluate()
    {
        bool isSateRunning = false;
       
        foreach (var node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeStat.RUNNING:
                    // Debug.Log("Running");
                    isSateRunning = true;
                    break;
                case NodeStat.SUCCESS:
                    // Debug.Log("Succes");

                    break;
                case NodeStat.FAILURE:
                    // Debug.Log("Failure");

                    return currentStat = NodeStat.FAILURE;

            }
        }

        return currentStat =isSateRunning? NodeStat.RUNNING: NodeStat.SUCCESS; 
        
    }
}
