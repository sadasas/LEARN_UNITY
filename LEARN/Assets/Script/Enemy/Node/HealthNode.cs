using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.AI;

public class HealthNode : Node
{
 
    UnitHealth _unitHealth;
    UnitEvent _unitEvent;
    float _minHealth;
    bool _healing = false;
    

    public HealthNode(UnitEvent unitEvent, UnitHealth unitHealth, float minHealth)
    {
        this._unitEvent = unitEvent;
        this._unitHealth = unitHealth;
        this._minHealth = minHealth;
    }


    
    public override NodeStat Evaluate()
    {
        _unitEvent.healingEvent += Healing;
        return CurrentHealth() ? NodeStat.SUCCESS : NodeStat.FAILURE;
    }

    bool Healing(bool healing)
    {
        return _healing = healing;
    }
    bool CurrentHealth()
    {
        if(_unitHealth.CurrentHealth(0) < _minHealth )
        {
          
            //Debug.Log("HEALTHNODE:hurt ");
            return true;
        }

        if (_healing) return true;


        return false;
    }
}
