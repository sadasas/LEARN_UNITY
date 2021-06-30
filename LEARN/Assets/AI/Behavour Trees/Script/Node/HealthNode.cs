using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthNode : Node
{
    private EnemyAI ai;
    private float treshold;

    public HealthNode(EnemyAI ai, float treshold)
    {
        this.ai = ai;
        this.treshold = treshold;
    }

    public override NodeState Evaluate()
    {
        return ai.currentHealth <= treshold ? NodeState.SUCCES : NodeState.FAILURE;
    }
}