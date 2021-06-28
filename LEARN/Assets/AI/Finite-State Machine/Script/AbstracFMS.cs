using FSM.FSMCode;
using FSM.NPCCode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FSM.AbstrackFMSCode
{
    public enum ExecutionState
    {
        NONE,
        ACTIVE,
        COMPLETE,
        TERMINATED,
    };

    public enum FSMStateType
    {
        IDLE,
        PATROL,
        CHASE,
    };

    public abstract class AbstracFMS : ScriptableObject
    {
        protected NavMeshAgent _navMeshAgent;
        protected NPC _npc;
        protected FiniteStateMachine _FSM;
        public ExecutionState ExecutionState { get; protected set; }
        public FSMStateType StateType { get; protected set; }
        public bool EnteredState { get; protected set; }

        public virtual void OnEnable()
        {
            ExecutionState = ExecutionState.NONE;
        }

        public virtual bool EnterState()
        {
            bool successAgent = true;
            bool successNPC = true;

            ExecutionState = ExecutionState.ACTIVE;
            successAgent = (_navMeshAgent != null);
            successNPC = (_npc != null);
            return successAgent & successNPC;
        }

        public abstract void UpdateState();

        public virtual bool ExitState()
        {
            ExecutionState = ExecutionState.COMPLETE;
            return true;
        }

        public virtual void SetNavMeshAgent(NavMeshAgent navMeshAgent)
        {
            if (navMeshAgent != null)
            {
                _navMeshAgent = navMeshAgent;
            }
        }

        public virtual void SetNPC(NPC npc)
        {
            if (npc != null)
            {
                _npc = npc;
            }
        }

        public virtual void SetFSM(FiniteStateMachine FSM)
        {
            if (FSM != null)
            {
                _FSM = FSM;
            }
        }
    }
}