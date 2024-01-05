using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    public void OnEnter(StateMachine machine);
    public void OnUpdate(StateMachine machine);
    public void OnFixedUpdate(StateMachine machine);
    public void OnLateUpdate(StateMachine machine);
    public void OnExit(StateMachine machine);
}
