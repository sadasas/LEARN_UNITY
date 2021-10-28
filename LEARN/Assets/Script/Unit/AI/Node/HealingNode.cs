using UnityEngine;



public class HealingNode : Node
{
    UnitHealth _health;
    UnitEvent _unitEvent;
    int _healthPlus;
    float _delay;
    float _time = 0f;

    public HealingNode(UnitEvent unitEvent, UnitHealth health, int healthPlus ,float delay)
    {
        this._delay = delay;
        this._unitEvent = unitEvent;
        this._health = health;
        this._healthPlus = healthPlus;
    }
    
    public override NodeStat Evaluate()
    {
        return Healing() <= _health.MaxHealth() ? NodeStat.SUCCESS : NodeStat.FAILURE;
    }

    int Healing()
    {

       
        if(_time>0f) _time -= Time.deltaTime;
       
        if (_health.CurrentHealth(0) < _health.MaxHealth() )
        {
           
            if (_health.CurrentHealth(0)+_healthPlus  <= _health.MaxHealth() && _time <= 0f)
            {
                _time = _delay;
                Debug.Log("HEALING NODE : Heal");
                _health.Healing(_healthPlus);
            }

            else
            {

                _health.CurrentHealth(_health.MaxHealth());
                  
            }

            _unitEvent.healingEvent?.Invoke(true);
        }

        else if(_health.CurrentHealth(0) >= _health.MaxHealth()) _unitEvent.healingEvent?.Invoke(false);

        Debug.Log("HEALING NODE : Not Heal");
       
        return _health.CurrentHealth(0);

    }


}
