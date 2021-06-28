using FSM.AbstrackFMSCode;
using FSM.NPCCode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FSM.FSMCode
{
    public class FiniteStateMachine : MonoBehaviour
    {
        private AbstracFMS _currentState;

        [SerializeField]
        private List<AbstracFMS> validStates;

        [SerializeField]
        private Dictionary<FSMStateType, AbstracFMS> _fsmStates;

        private void Awake()
        {
            _currentState = null;
            _fsmStates = new Dictionary<FSMStateType, AbstracFMS>();
            NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
            NPC npc = GetComponent<NPC>();

            foreach (AbstracFMS state in validStates)
            {
                state.SetNavMeshAgent(navMeshAgent);
                state.SetNPC(npc);
                state.SetFSM(this);
                _fsmStates.Add(state.StateType, state);
            }
        }

        private void Start()
        {
            EnterState(FSMStateType.IDLE);
        }

        private void Update()
        {
            if (_currentState != null)
            {
                _currentState.UpdateState();
            }
        }

        #region STATE MANAGEMENT

        public void EnterState(AbstracFMS nextState)
        {
            if (nextState == null)
            {
                return;
            }

            if (_currentState != null)
            {
                _currentState.ExitState();
            }
            _currentState = nextState;
            _currentState.EnterState();
        }

        public void EnterState(FSMStateType stateType)
        {
            if (_fsmStates.ContainsKey(stateType))
            {
                Debug.Log("enter");
                AbstracFMS nextstate = _fsmStates[stateType];
                // _currentState.ExitState();
                EnterState(nextstate);
            }
        }

        #endregion STATE MANAGEMENT
    }
}