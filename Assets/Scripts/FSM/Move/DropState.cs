using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropState : State
{
    public void OnEnter(StateMachine machine)
    {
        Debug.Log("drop enter");
        machine.config.SetJumpInput(false);
        machine.anim.SetBool("Jump", true);
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
        Ray ray = new Ray(machine.transform.position, machine.transform.forward);
        Debug.DrawRay(machine.transform.position, machine.transform.forward * 0.7f, Color.red, 1f);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 0.7f, LayerMask.NameToLayer("Player")) == false)
        {
            machine.rigid.MovePosition(machine.transform.position + 0.5f * Time.deltaTime * machine.config.MoveSpeed * machine.config.MoveDir_Global);
        }

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
