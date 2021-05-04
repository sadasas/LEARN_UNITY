using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    [SerializeField]
    private AbstracFMS _startingState;

    private AbstracFMS _currentState;

    private void Awake()
    {
        _currentState = null;
    }

    private void Start()
    {
        if (_startingState != null)
        {
            EnterState(_startingState);
        }
    }

    private void Update()
    {
        if (_currentState != null) _currentState.UpdateState();
    }

    #region STATE MANAGEMENT

    public void EnterState(AbstracFMS nextState)
    {
        if (nextState == null)
        {
            return;
        }
        _currentState = nextState;
        _currentState.EnterState();
    }

    #endregion STATE MANAGEMENT
}