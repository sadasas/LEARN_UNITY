using FSM.AbstrackFMSCode;
using FSM.FSMCode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FSM.NPCCode
{
    [RequireComponent(typeof(NavMeshAgent), typeof(FiniteStateMachine))]
    public class NPC : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;
        private FiniteStateMachine finiteStateMachine;

        public Transform[] patrolPoint;
        public Transform playerPos, enemy;
        public float rangeChase, rangeKabur;
        public LayerMask playerMask;
        private bool chased = false;

        private void Awake()
        {
            finiteStateMachine = GetComponent<FiniteStateMachine>();
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            playerPos = GameObject.FindGameObjectWithTag("Player").transform;
            SearchPlayer();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Debug.Log("DRAW GIZMOS");

            Gizmos.DrawWireSphere(enemy.transform.position, rangeChase);
            Gizmos.DrawWireSphere(enemy.transform.position, rangeKabur);
        }

        private void SearchPlayer()
        {
            if (!chased)
            {
                if (Physics.CheckSphere(enemy.transform.position, rangeChase, playerMask))
                {
                    chased = true;
                    Debug.Log("CHECK SPHERE : Search player");
                    finiteStateMachine.EnterState(FSMStateType.CHASE);
                }
            }

            if (chased)
            {
                if (Physics.CheckSphere(enemy.transform.position, rangeKabur, playerMask))
                {
                }
                else
                {
                    chased = false;
                    Debug.Log("CHECK SPHERE : Player out of range");
                    finiteStateMachine.EnterState(FSMStateType.IDLE);
                }
            }
        }
    }
}