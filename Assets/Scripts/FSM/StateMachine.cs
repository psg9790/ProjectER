using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    // 플레이어 정보
    public PlayerConfig Config { get; private set; }
    public Animator Animator { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    // 상태저장용 딕셔너리
    protected Dictionary<string, State> stateTable;
    // 이전 상태
    protected State prevState;
    // 현재 상태
    public State curState { get; private set; }

    [SerializeField] MachineInfo machineInfo;

    protected void Awake()
    {
        Config = GetComponent<PlayerConfig>();
        Animator = GetComponentInChildren<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    protected void Start()
    {
        Initialize();
    }

    protected void Initialize()
    {
        stateTable = new Dictionary<string, State>();

        Type enumType = Type.GetType(machineInfo.ToString());
        foreach (string name in enumType.GetEnumNames())
        {
            Type classType = Type.GetType(name + "State");
            System.Object sub = Activator.CreateInstance(classType);
            stateTable.Add(name, sub as State);
        }

        ChangeState("Idle");
    }

    protected void Update()
    {
        if (curState is null)
            return;
        curState.OnUpdate(this);
    }

    private void FixedUpdate()
    {
        if (curState is null)
            return;
        curState.OnFixedUpdate(this);
    }

    private void LateUpdate()
    {
        if (curState is null)
            return;
        curState.OnLateUpdate(this);
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
            prevState.OnExit(this);
        curState.OnEnter(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawCube(transform.position + Vector3.up * 0.05f, new Vector3(0.5f, 0.2f, 0.5f));
    }
}
