using UnityEngine;
using UnityEngine.AI;

public class ShootNode : Node
{
    NavMeshAgent _agent;
    UnitEvent _unitEvent;
    float _distanceShoot;
    float _timeReloadReset;
    float _distanceBetweenShoot;
    float _rangeSearch;

    float _timeReload = 0f;

    public Transform target { get; set; }

    public ShootNode(NavMeshAgent agent,UnitEvent unitEvent,float distanceShoot,float timeReloadReset, float distanceBetweenShoot,float rangeSearch)
    {
        this._distanceBetweenShoot = distanceBetweenShoot;
        this._distanceShoot = distanceShoot;
        this._timeReloadReset = timeReloadReset;
        this._unitEvent = unitEvent;
        this._agent = agent;
        this._rangeSearch = rangeSearch;
    }


    public override NodeStat Evaluate()
    {
        if (_timeReload > 0f) _timeReload -= Time.deltaTime;
        //Debug.Log(target);
        return currentStat = Shoot()? NodeStat.SUCCESS:NodeStat.FAILURE;
    }

 
    bool Shoot()
    {
      
        if (target == null  ) return false;

            _agent.transform.LookAt(target);

            if (_agent.hasPath) _agent.ResetPath();
            float distance = Vector3.Distance(target.position, _agent.transform.position);
               Debug.Log(distance);

                //calculate
                float _input = _distanceShoot + _distanceBetweenShoot;

                if (_input >= _rangeSearch)
                {
                    _distanceBetweenShoot -= 1f;
                    _distanceShoot -= 1f;
                }

                if (distance > _distanceShoot+ _distanceBetweenShoot) return false;

                    if (distance < _distanceShoot + _distanceBetweenShoot )
                        {
                            _agent.stoppingDistance = _distanceShoot + _distanceBetweenShoot;

                            if (_timeReload <= 0f )
                            {
                                _timeReload = _timeReloadReset;
                                if(distance <_distanceShoot - _distanceBetweenShoot *2)
                                 {
                                        Debug.Log(_distanceShoot - _distanceBetweenShoot * 2);
                                      Debug.Log("SHOOTNODE:Short shoot");
                                        _unitEvent.shootEvent?.Invoke(1);
                                }
                                else if( distance > _distanceShoot - _distanceBetweenShoot * 2 && distance < _distanceShoot - _distanceBetweenShoot)
                                {
                                        Debug.Log(_distanceShoot - _distanceBetweenShoot * 2 + _distanceShoot - _distanceBetweenShoot);
                                        Debug.Log("SHOOTNODE:Medium shoot");
                                        _unitEvent.shootEvent?.Invoke(2);
                                }
                                else 
                                {

                                        Debug.Log( _distanceShoot + _distanceBetweenShoot);
                                        Debug.Log("SHOOTNODE:Long shoot");
                                        _unitEvent.shootEvent?.Invoke(3);
                                }
                               
                              
                            }

                            return true;
                        }


        //  _agent.stoppingDistance = 3f;

        Debug.Log("SHOOTNODE: failure");
        return false;

    }
    //  _agent.isStopped = false;
       
    }

