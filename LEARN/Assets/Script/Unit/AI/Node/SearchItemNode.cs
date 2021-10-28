
using UnityEngine;
using UnityEngine.AI;

public class SearchItemNode : Node
{

    float _rangeSearch;
    NavMeshAgent _agent;

    public SearchItemNode(float rangeSearch,NavMeshAgent agent)
    {
        this._rangeSearch = rangeSearch;
        this._agent = agent;
    }
    public override NodeStat Evaluate()
    {
        return SearchItem() ? NodeStat.SUCCESS : NodeStat.FAILURE; 
    }

   
    bool SearchItem()
    {
        Collider[] hitCollider = Physics.OverlapSphere(_agent.transform.position, _rangeSearch);
        foreach(var collider in hitCollider)
        {
            if(collider.CompareTag("Item"))
            {
                Debug.Log("SEARCHITEMNODE : Find item");
                GoToItem(collider.transform);

                return true;
            }
        }
        Debug.Log("SEARCHITEMNODE :not  Find item");
        return false;
    }

    Transform GoToItem(Transform item)
    {
        if (_agent.hasPath) _agent.ResetPath();
        _agent.stoppingDistance = 0f;
        _agent.SetDestination(item.position);

        return item;
    }
}
