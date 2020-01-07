using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MoveBehavior
{
    override protected void OnEnterState(MoveBehavior.MoveState _state)
    {
        switch (_state)
        {
            case MoveState.Setup:
                Debug.Log("SETUP FLY");
                WaitSomeTimeForSetup(3f);
                break;
            case MoveState.Moving:
                break;
            case MoveState.TargetReached:
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
                break;
            case MoveState.TargetReached:
                break;
            default:
                break;
        }
    }
}
