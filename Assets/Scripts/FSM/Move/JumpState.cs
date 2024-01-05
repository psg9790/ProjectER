using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    StateMachine machine;
    Vector3 jumpStartPos;
    bool doDetection = false;
    public void OnEnter(StateMachine machine)
    {
        Debug.Log("jump enter");
        machine.Config.SetJumpInput(false);
        this.machine = machine;
        doDetection = false;

        machine.Animator.SetBool("Jump", true);

        Ray ray = new Ray(machine.transform.position + Vector3.up * 0.9f, -Vector3.up);
        Debug.DrawRay(machine.transform.position + Vector3.up * 0.9f, -Vector3.up, Color.red, 5f);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 1, LayerMask.NameToLayer("Player")))
        {
            jumpStartPos = hitInfo.point;
            machine.Rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
            machine.StartCoroutine(StartDetection());
        }
        else
        {
            Debug.Log("jump failed");
            machine.ChangeState("Idle");
        }
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
        machine.transform.position += 0.5f * Time.deltaTime * machine.Config.MoveSpeed * machine.Config.MoveDir_Global;
        machine.transform.forward = machine.Config.LookDir;

        if (doDetection == false)
            return;
        Ray ray = new Ray(machine.transform.position + Vector3.up * 0.9f, -Vector3.up);
        Debug.DrawRay(machine.transform.position + machine.transform.forward + Vector3.up * 0.9f, -Vector3.up, Color.red, 5f);
        RaycastHit hitInfo;
        // if (Physics.Raycast(ray, out hitInfo, 1, LayerMask.NameToLayer("Player")))
        // {
        //     if (machine.Config.InputDir_Local.magnitude > 0)
        //     {
        //         machine.Animator.SetBool("Move", true);
        //         machine.ChangeState("Move");
        //     }
        //     else
        //     {
        //         machine.ChangeState("Idle");
        //     }
        // }
        if (Physics.BoxCast(machine.transform.position + Vector3.up * 0.05f, new Vector3(0.5f, 0.2f, 0.5f), -Vector3.up, machine.transform.rotation, 0.05f, LayerMask.NameToLayer("Player")))
        {
            if (machine.Config.InputDir_Local.magnitude > 0)
            {
                machine.Animator.SetBool("Move", true);
                machine.ChangeState("Move");
            }
            else
            {
                machine.ChangeState("Idle");
            }
        }
    }


    IEnumerator StartDetection()
    {
        yield return new WaitForSeconds(0.5f);
        doDetection = true;
        // Debug.Log("do detection");
    }
}
