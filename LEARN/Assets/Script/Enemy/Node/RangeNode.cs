
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.ProBuilder;

public class RangeNode : Node
{
    public Transform target { get; set; }
    NavMeshAgent _agent;
    float _rangeSearch;
    float _agentStopingDistance;
    string _targetSearch;
    
    public RangeNode(NavMeshAgent agent,float rangeSearch,float agentStopingDistance , string _targetSearch)
    {
        this._agentStopingDistance = agentStopingDistance;
        this._agent = agent;
        this._rangeSearch = rangeSearch;
        this._targetSearch = _targetSearch;
    }
    public override NodeStat Evaluate()
    {
        return SearchEnemy() ? NodeStat.FAILURE : NodeStat.FAILURE;
    }
    bool SearchEnemy()
    {

        Collider[] allHit = Physics.OverlapSphere(_agent.transform.position, _rangeSearch);
            foreach (var item in allHit)
            {
                //Debug.Log("Search");
                if (item.CompareTag(_targetSearch) && item.gameObject != _agent.gameObject)
                {
 
                        if (target == null ) 
                        {
                            target = item.transform;
                        }

                _agent.stoppingDistance = _agentStopingDistance;
                return true;

                }
            }

        _agent.stoppingDistance = 0.5f;
        target = null;
        return false;
    }

}
