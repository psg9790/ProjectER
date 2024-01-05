using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    // 플레이어 정보
    protected PlayerConfig config;
    // 상태저장용 딕셔너리
    protected Dictionary<string, State> stateTable;
    // 이전 상태
    protected State prevState;
    // 현재 상태
    protected State curState;

    [SerializeField] StateInfo stateInfo;

    protected void Awake()
    {
        config = GetComponent<PlayerConfig>();
    }

    protected void Start()
    {
        Initialize();
    }

    protected void Initialize()
    {
        Type enumType = Type.GetType(stateInfo.ToString());

    }

    protected void Update()
    {
        curState.OnUpdate();
    }

    private void FixedUpdate()
    {
        curState.OnFixedUpdate();
    }

    private void LateUpdate()
    {
        curState.OnLateUpdate();
    }

    // 상태저장용 딕셔너리 초기화

    public void ChangeState(State nextState)
    {
        ChangeState(nextState.ToString());
    }

    public void ChangeState(string nextState)
    {
        stateTable.TryGetValue(nextState, out State foundState);
        if (foundState == null)
        {
            Debug.LogError($"( {nextState} ) state not found");
            return;
        }
        prevState = curState;
        curState = foundState;

        if (prevState is null == false)
            prevState.OnExit();
        curState.OnEnter();
    }
}
