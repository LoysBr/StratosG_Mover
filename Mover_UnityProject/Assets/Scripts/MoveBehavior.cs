using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveBehavior : MonoBehaviour
{
    public enum MoveState
    {
        None,
        Setup,
        Moving,
        TargetReached
    }

    private MoveState _CurrentState;
    public MoveState CurrentState { get { return _CurrentState; } }

    void Start()
    {
        _CurrentState = MoveState.Setup;
    }
    
    abstract protected void OnEnterState(MoveState _state);
    abstract protected void OnLeaveState(MoveState _state);
    abstract protected void ExecuteState(MoveState _state);

    protected void SwitchState(MoveState _state)
    {
        OnLeaveState(_CurrentState);       
        OnEnterState(_state);

        _CurrentState = _state;
    }
 
    protected IEnumerator WaitSomeTimeForSetup(float _time)
    {
        yield return new WaitForSeconds(_time);
        SwitchState(MoveState.Moving);
    }
}
