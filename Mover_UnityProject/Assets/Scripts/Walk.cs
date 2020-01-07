using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MoveBehavior
{
    override protected void OnEnterState(MoveBehavior.MoveState _state)
    {
        switch (_state)
        {            
            case MoveState.Setup:
                Debug.Log("SETUP WALK (1sec)");
                StartCoroutine(WaitSomeTimeForSetup(1f));
                break;
            case MoveState.Moving:
                Debug.Log("Moving WALK");                
                break;
            case MoveState.TargetReached:
                Debug.Log("TargetReached WALK");
                break;
            default:
                break;
        }
    }

    override protected void OnLeaveState(MoveBehavior.MoveState _state)
    {
        switch (_state)
        {
            case MoveState.None:
                break;
            case MoveState.Setup:
                break;
            case MoveState.Moving:
                RigidBody.velocity = Vector3.zero;
                break;
            case MoveState.TargetReached:
                break;
            default:
                break;
        }
    }
    override protected void ExecuteState(MoveBehavior.MoveState _state)
    {
        switch (_state)
        {
            case MoveState.None:
                break;
            case MoveState.Setup:
                break;
            case MoveState.Moving:
                //Very basic implementation
                RigidBody.velocity = (Target.transform.position - transform.position).normalized * Speed;
                break;
            case MoveState.TargetReached:
                break;
            default:
                break;
        }
    }
}
