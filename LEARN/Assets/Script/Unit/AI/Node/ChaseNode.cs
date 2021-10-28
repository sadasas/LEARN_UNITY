
using UnityEngine;
using UnityEngine.AI;

public class ChaseNode : Node
{
    NavMeshAgent _agent;
    float _agentStoppingDistance;
  
    
    public Transform target { get; set; }
   
    public ChaseNode (NavMeshAgent agent ,float agentStoppingDistance)
    {
        this._agentStoppingDistance = agentStoppingDistance;
        this._agent = agent;
    
    }

   

    public override NodeStat Evaluate()
    {
        return ChaseTarget() ? NodeStat.RUNNING : NodeStat.FAILURE;
    }
    

  
    bool ChaseTarget()
    {
        if (target == null ) return false;

        //  Debug.Log("Chase");
        if (_agent.hasPath) _agent.ResetPath();
         _agent.SetDestination(target.position);

 
        return ReachTarget();
    }   

    bool ReachTarget()
    {
       // Debug.Log(_agent.remainingDistance);
       
        if (_agent.remainingDistance < _agentStoppingDistance)
        {
            Debug.Log("reach");
            return false;
        }
       
        
        return true;
    }
}
