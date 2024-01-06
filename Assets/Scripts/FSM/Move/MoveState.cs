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
        //machine.transform.position += Time.deltaTime * machine.Config.MoveSpeed * machine.Config.MoveDir_Global;
        machine.cc.Move(Time.deltaTime * machine.Config.MoveSpeed * machine.Config.MoveDir_Global);
        Debug.DrawRay(machine.transform.position, machine.Config.MoveSpeed * machine.Config.MoveDir_Global, Color.red, 1f);

        machine.Animator.SetFloat("Strafe", machine.Config.InputDirFollow.x);
        machine.Animator.SetFloat("Forward", machine.Config.InputDirFollow.z);
        machine.transform.forward = machine.Config.LookDir;


        if (machine.Config.XZInputDir == Vector2.zero)
        {
            machine.ChangeState("Idle");
        }
    }
}
