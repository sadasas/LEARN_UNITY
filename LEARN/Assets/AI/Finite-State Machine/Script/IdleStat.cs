using FSM.AbstrackFMSCode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM.IdleStatCode
{
    [CreateAssetMenu(fileName = ("Unity FSM"), menuName = ("State/ Idle"), order = 1)]
    public class IdleStat : AbstracFMS
    {
        [SerializeField]
        private float idleDuration = 3f;

        private float totalDuration = 0f;

        public override void OnEnable()
        {
            base.OnEnable();
            StateType = FSMStateType.IDLE;
        }

        public override bool EnterState()
        {
            EnteredState = base.EnterState();
            if (EnteredState)
            {
                totalDuration = 0f;
                Debug.Log("ENTER IDLE");
            }
            return EnteredState;
        }

        public override void UpdateState()
        {
            if (EnteredState)
            {
                Debug.Log("UPDATE IDLE");
                totalDuration += Time.deltaTime;

                if (totalDuration >= idleDuration)
                {
                    _FSM.EnterState(FSMStateType.PATROL);
                }
            }
        }

        public override bool ExitState()
        {
            Debug.Log("EXIT IDLE");
            base.ExitState();
            return true;
        }
    }
}