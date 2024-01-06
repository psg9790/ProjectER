using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;
using System.Runtime.InteropServices;

public class PlayerConfig : MonoBehaviour
{
    #region CameraDirection
    private Vector3 m_flatCamForward;
    public Vector3 FlatCamForward => m_flatCamForward;
    public void SetFlatCamForward(Vector3 flatCamForward)
    {
        m_flatCamForward = flatCamForward;
    }

    private Vector3 m_flatCamRight;
    public Vector3 FlatCamRight => m_flatCamRight;
    #endregion

    #region WASD
    private Vector2 m_inputDir;
    [SerializeField] private float m_moveSpeed = 12f;
    private float m_runInput;   // 0 or 1
    [SerializeField] private float m_runBoost = 1f;

    private Vector3 m_inputDir_follow;
    private float m_inputDir_follow_lerp = 0.1f;

    private bool m_jump_input;
    /// <summary>
    /// 점프 키 입력시 활성화 후 꺼짐
    /// </summary>
    [BoxGroup("WASD")]
    [ShowInInspector]
    [ReadOnly]
    public bool JumpInput => m_jump_input;
    /// <summary>
    /// 4방향 키 입력에 속도 적용
    /// </summary>
    [BoxGroup("WASD")]
    [ShowInInspector]
    [ReadOnly]
    public Vector2 InputDir_Local
    {
        get
        {
            return m_inputDir.normalized * (1f + m_runInput * m_runBoost);
        }
    }

    /// <summary>
    /// 4방향 키 입력을 부드럽게 따라가는 값
    /// </summary>
    [BoxGroup("WASD")]
    [ShowInInspector]
    [ReadOnly]
    public Vector3 InputDirFollow
    {
        get
        {
            return m_inputDir_follow;
        }
    }

    /// <summary>
    /// 카메라 방향 기준 움직임 벡터
    /// </summary>
    [BoxGroup("WASD")]
    [ShowInInspector]
    [ReadOnly]
    public Vector3 MoveDir_Global
    {
        get
        {
            Vector3 ret = FlatCamForward * m_inputDir_follow.z + FlatCamRight * m_inputDir_follow.x;
            return ret;
        }
    }

    /// <summary>
    /// 평면 움직임 벡터
    /// </summary>
    [BoxGroup("WASD")]
    [ShowInInspector]
    [ReadOnly]
    public Vector2 XZInputDir
    {
        get
        {
            return m_inputDir;
        }
    }

    /// <summary>
    /// 플레이어가 바라볼 방향
    /// </summary>
    [BoxGroup("WASD")]
    [ShowInInspector]
    [ReadOnly]
    public Vector3 LookDir
    {
        get
        {
            Vector3 ret = FlatCamForward;
            ret.y = 0;
            return ret;
        }
    }

    /// <summary>
    /// 이동 속도
    /// </summary>
    [BoxGroup("WASD")]
    [ShowInInspector]
    [ReadOnly]
    public float MoveSpeed
    {
        get
        {
            return m_moveSpeed;
        }
    }
    #endregion

    Camera cam;

    #region MonoBehavior
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        CalcFlatCamDir();


        m_inputDir_follow = new Vector3(Mathf.Lerp(m_inputDir_follow.x, InputDir_Local.x, m_inputDir_follow_lerp),
            InputDir_Local.y, Mathf.Lerp(m_inputDir_follow.z, InputDir_Local.y, m_inputDir_follow_lerp));

        //m_inputDir.y -= 1;
    }
    #endregion

    #region Methods
    public void SetFlatCamRight(Vector3 flatCamRight)
    {
        m_flatCamRight = flatCamRight;
    }
    public void SetJumpInput(bool jumpInput)
    {
        m_jump_input = jumpInput;
    }
    void CalcFlatCamDir()
    {
        Vector3 dir = cam.transform.forward;
        dir.y = 0;
        SetFlatCamForward(dir);

        dir = cam.transform.right;
        dir.y = 0;
        SetFlatCamRight(dir);
    }
    public void SetXZInputDir(Vector2 dir)
    {
        m_inputDir.x = Math.Clamp(dir.x, -1, 1);
        m_inputDir.y = Math.Clamp(dir.y, -1, 1);
    }
    public void SetRunInput(float value)
    {
        m_runInput = value;
    }
    #endregion
}
