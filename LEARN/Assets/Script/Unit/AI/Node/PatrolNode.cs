
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PatrolNode : Node
{
    List<Transform> pointPatrol ;
    NavMeshAgent agent;
   

    int random;
    bool colapse;

    public PatrolNode(List<Transform> _pointPatrol,NavMeshAgent _agent)
    {
        this.pointPatrol = _pointPatrol;
        this.agent = _agent;
     
    }

    public override NodeStat Evaluate()
    {
        SetRandom();    

        return currentStat = SetDestination() ? NodeStat.SUCCESS : NodeStat.RUNNING;

    }

        
    void SetRandom()
    {
        if (!colapse)
        {
           // if (agent.hasPath) agent.ResetPath();
            // Debug.Log("Random");
            colapse = true;
            random = Random.Range(0, pointPatrol.Count-1);
        }
    }
    bool SetDestination()
    {


        //Debug.Log( "Set");
        
        agent.SetDestination(pointPatrol[random].position);
       return ReachDestination(random);

       
    }

    bool ReachDestination(int i)
    {

        if (agent.remainingDistance < 0.6f)
        {
            colapse = false;
            //Debug.Log("Reach");
            return true;

           
        }

        return false;
      
            
    }
}
