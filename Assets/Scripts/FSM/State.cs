using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void OnEnter(PlayerConfig config);
    public abstract void OnUpdate(PlayerConfig config);
    public abstract void OnExit(PlayerConfig config);
}
