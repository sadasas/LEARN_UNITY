using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM.AbstrackFMSCode;

[CreateAssetMenu(fileName = ("Unity FSM"), menuName = ("State/ Chase"), order = 3)]
public class ChaseStat : AbstracFMS
{
    private Transform _playerPos;

    public override void OnEnable()
    {
        base.OnEnable();
        StateType = FSMStateType.CHASE;
    }

    public override bool EnterState()
    {
        EnteredState = false;
        if (base.EnterState())
        {
            if (_npc.playerPos == null)
            {
                Debug.Log("CHASE STATE : Transform player is empty");
            }
            else
            {
                EnteredState = true;
            }
        }

        return EnteredState;
    }

    public override void UpdateState()
    {
        _playerPos = _npc.playerPos;
        if (EnteredState)
        {
            ChasePlayer();
            if (Vector3.Distance(_navMeshAgent.transform.position, _playerPos.transform.position) <= 1f)
            {
                Debug.Log("PATROL STATE: Reach player target");
                _FSM.EnterState(FSMStateType.IDLE);
            }
        }
    }

    private void ChasePlayer()
    {
        if (_navMeshAgent != null && _playerPos != null)
        {
            _navMeshAgent.SetDestination(_playerPos.transform.position);
        }
    }
}