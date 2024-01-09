using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public void OnEnter(StateMachine machine)
    {
        Debug.Log("idle enter");
        machine.rigid.velocity = Vector3.zero;
    }

    public void OnExit(StateMachine machine)
    {
        //throw new System.NotImplementedException();
        // Debug.Log("idle exit");
    }

    public void OnFixedUpdate(StateMachine machine)
    {
        //throw new System.NotImplementedException();
    }

    public void OnLateUpdate(StateMachine machine)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUpdate(StateMachine machine)
    {
        //throw new System.NotImplementedException();
        if (machine.config.XZInputDir != Vector2.zero)
        {
            machine.ChangeState("Move");
        }
        if (machine.config.JumpInput)
        {
            machine.ChangeState("Jump");
        }
    }
}
