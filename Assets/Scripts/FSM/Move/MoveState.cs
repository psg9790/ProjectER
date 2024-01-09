using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    public void OnEnter(StateMachine machine)
    {
        machine.anim.SetBool("Move", true);
        Debug.Log("move enter");
    }

    public void OnExit(StateMachine machine)
    {
        machine.anim.SetBool("Move", false);
        // Debug.Log("move exit");
    }

    public void OnFixedUpdate(StateMachine machine)
    {
    }

    public void OnLateUpdate(StateMachine machine)
    {
    }

    public void OnUpdate(StateMachine machine)
    {
        machine.rigid.velocity = machine.config.MoveSpeed * machine.config.MoveDir_Global;

        Debug.DrawRay(machine.transform.position, machine.config.MoveSpeed * machine.config.MoveDir_Global, Color.red, 1f);

        machine.anim.SetFloat("Strafe", machine.config.InputDirFollow.x);
        machine.anim.SetFloat("Forward", machine.config.InputDirFollow.z);
        machine.transform.forward = machine.config.LookDir;


        if (machine.config.XZInputDir == Vector2.zero)
        {
            machine.ChangeState("Idle");
        }
        if (machine.config.JumpInput)
        {
            machine.ChangeState("Jump");
        }
    }
}
