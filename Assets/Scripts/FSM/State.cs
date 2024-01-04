using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State
{
    public void OnEnter(PlayerConfig config);
    public void OnUpdate(PlayerConfig config);
    public void OnExit(PlayerConfig config);
}
