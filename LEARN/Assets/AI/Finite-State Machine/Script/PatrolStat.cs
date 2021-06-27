using FSM.AbstrackFMSCode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM.PatrolStatCode
{
    [CreateAssetMenu(fileName = ("PatrolState"), menuName = ("State/ Patrol"), order = 2)]
    public class PatrolStat : AbstracFMS
    {
        public Transform[] patrolPoint;
        private int patrolPointIndex;

        public override void OnEnable()
        {
            base.OnEnable();
            patrolPointIndex = -1;
            StateType = FSMStateType.PATROL;
        }

        public override bool EnterState()
        {
            EnteredState = false;
            if (base.EnterState())
            {
                patrolPoint = _npc.patrolPoint;

                if (patrolPoint == null || patrolPoint.Length == 0)
                {
                    Debug.Log("PATROLSTATE = FAILED TO GRAB PATROL POINT FROM NPC");
                }
                else
                {
                    if (patrolPointIndex < 0)
                    {
                        patrolPointIndex = Random.Range(0, patrolPoint.Length);
                    }
                    else
                    {
                        patrolPointIndex = (patrolPointIndex + 1) % patrolPoint.Length;
                    }
                    EnteredState = true;
                }
            }

            SetDestination(patrolPoint[patrolPointIndex]);

            return EnteredState;
        }

        public override void UpdateState()
        {
            if (EnteredState)
            {
                if (Vector3.Distance(_navMeshAgent.transform.position, patrolPoint[patrolPointIndex].transform.position) <= 1f)
                {
                    _FSM.EnterState(FSMStateType.IDLE);
                }
            }
        }

        private void SetDestination(Transform destination)
        {
            if (_navMeshAgent != null && destination != null)
            {
                _navMeshAgent.SetDestination(destination.transform.position);
            }
        }
    }
}