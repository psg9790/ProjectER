using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class JumpState : State
{
    bool groundCheck = false;
    public void OnEnter(StateMachine machine)
    {
        groundCheck = false;
        Debug.Log("jump enter");
        machine.config.SetJumpInput(false);
        machine.anim.SetBool("Jump", true);
        machine.rigid.AddForce(Vector3.up * 5.5f, ForceMode.Impulse);

        Task.Run(() => DoGroundCheck(500));
    }

    public void OnExit(StateMachine machine)
    {
        machine.anim.SetBool("Jump", false);
    }

    public void OnFixedUpdate(StateMachine machine)
    {
    }

    public void OnLateUpdate(StateMachine machine)
    {
    }

    public void OnUpdate(StateMachine machine)
    {
        if (groundCheck == true)
        {
            if (machine.gc.IsGrounded() == true)
            {
                if (machine.config.XZInputDir != Vector2.zero)
                {
                    machine.ChangeState("Move");
                }
                else
                {
                    machine.ChangeState("Idle");
                }
            }
        }
    }

    async Task DoGroundCheck(int milli)
    {
        await Task.Delay(milli);
        groundCheck = true;
    }
}
