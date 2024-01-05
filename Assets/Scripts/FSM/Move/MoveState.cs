using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    public void OnEnter(StateMachine machine)
    {
        machine.Animator.SetBool("Move", true);
        Debug.Log("move enter");
    }

    public void OnExit(StateMachine machine)
    {
        machine.Animator.SetBool("Move", false);
        Debug.Log("move exit");
    }

    public void OnFixedUpdate(StateMachine machine)
    {
    }

    public void OnLateUpdate(StateMachine machine)
    {
    }

    public void OnUpdate(StateMachine machine)
    {
        machine.transform.position += Time.deltaTime * machine.Config.MoveSpeed * machine.Config.MoveDir_Global;
        machine.Animator.SetFloat("Strafe", machine.Config.FollowDir.x);
        machine.Animator.SetFloat("Forward", machine.Config.FollowDir.z);
        machine.transform.forward = machine.Config.LookDir;


        if (machine.Config.FollowDir.sqrMagnitude < 0.15f && machine.Config.InputDir_Local == Vector3.zero)
        {
            machine.ChangeState("Idle");
        }
    }
}
