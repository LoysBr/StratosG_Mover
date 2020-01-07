using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MoveBehavior
{
    [SerializeField]
    [Tooltip("The height of flying")]
    private float FlyingHeight;
    
    override protected void OnEnterState(MoveBehavior.MoveState _state)
    {
        switch (_state)
        {
            case MoveState.Setup:
                Debug.Log("SETUP FLY");                
                RigidBody.constraints = RigidbodyConstraints.FreezeRotation;
                break;
            case MoveState.Moving:
                Debug.Log("Moving FLY");
                break;
            case MoveState.TargetReached:
                Debug.Log("TargetReached FLY");
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
                RigidBody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
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
                if(transform.position.y <= FlyingHeight)
                    RigidBody.velocity = Vector3.up * Speed;
                else
                {
                    RigidBody.velocity = Vector3.zero;
                    SwitchState(MoveState.Moving);
                }                
                break;
            case MoveState.Moving:
                if (!IsOnTopOfTarget())
                {
                    RigidBody.velocity = (new Vector3(Target.transform.position.x, 0, Target.transform.position.z) -
                        new Vector3(transform.position.x, 0, transform.position.z) ).normalized * Speed;
                }
                else
                {
                    RigidBody.velocity = -Vector3.up * Speed;
                }
                break;
            case MoveState.TargetReached:
                break;
            default:
                break;
        }
    }

    private bool IsOnTopOfTarget()
    {
        return (new Vector3(Target.transform.position.x, 0, Target.transform.position.z) -
                        new Vector3(transform.position.x, 0, transform.position.z)).magnitude < Target.radius;
    }
}
