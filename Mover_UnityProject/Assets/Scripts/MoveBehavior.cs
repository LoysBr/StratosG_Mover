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

    [SerializeField]
    protected Collider Target;
    [SerializeField]
    protected float Speed;

    protected Rigidbody RigidBody;

    protected void Start()
    {
        RigidBody = GetComponent<Rigidbody>();
        _CurrentState = MoveState.Setup;
        OnEnterState(_CurrentState);
    }

    protected void Update()
    {
        ExecuteState(_CurrentState);
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

    protected void OnTriggerEnter(Collider _trigger)
    {
        if(_trigger.gameObject == Target.gameObject)
        {
            SwitchState(MoveState.TargetReached);
        }
    }
}
