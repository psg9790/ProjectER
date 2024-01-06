using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    public void OnEnter(StateMachine machine)
    {
        Debug.Log("jump enter");
        machine.Config.SetJumpInput(false);
        machine.Animator.SetBool("Jump", true);
    }

    public void OnExit(StateMachine machine)
    {
        machine.Animator.SetBool("Jump", false);
    }

    public void OnFixedUpdate(StateMachine machine)
    {
    }

    public void OnLateUpdate(StateMachine machine)
    {
    }

    public void OnUpdate(StateMachine machine)
    {
        // machine.cc.Move(Time.deltaTime * machine.Config.MoveSpeed * machine.Config.MoveDir_Global);
        // machine.Config.UpdateJumpValue();


        // Debug.Log(machine.GetComponent<GroundChecker>().IsGrounded());
        // if (machine.GetComponent<GroundChecker>().IsGrounded())
        // {
        //     if (machine.Config.InputDir_Local.magnitude > 0)    // 이동 입력중이면 Move로
        //     {
        //         machine.Animator.SetBool("Move", true);
        //         machine.ChangeState("Move");
        //     }
        //     else    // Idle로
        //     {
        //         machine.ChangeState("Idle");
        //     }
        // }
    }
}
