using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

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
    public void SetFlatCamRight(Vector3 flatCamRight)
    {
        m_flatCamRight = flatCamRight;
    }
    #endregion

    #region WASD
    private Vector3 m_moveDir;
    private float m_moveSpeed = 3f;
    private float m_runInput;
    private float m_runBoost = 2f;

    private Vector3 m_moveDir_follow;
    private float m_moveDir_follow_lerp = 0.05f;
    private Vector3 m_lookDir_follow;
    private float m_lookDir_follow_lerp = 0.025f;

    [BoxGroup("WASD")]
    [ShowInInspector]
    [ReadOnly]
    public Vector3 FollowDir
    {
        get
        {
            return m_moveDir_follow;
        }
    }

    [BoxGroup("WASD")]
    [ShowInInspector]
    [ReadOnly]
    public Vector3 LookDir => m_lookDir_follow;

    [BoxGroup("WASD")]
    [ShowInInspector]
    [ReadOnly]
    public Vector3 InputDir_Local
    {
        get
        {
            return m_moveDir.normalized * (1f + m_runInput * m_runBoost);
        }
    }

    [BoxGroup("WASD")]
    [ShowInInspector]
    [ReadOnly]
    public Vector3 MoveDir_Global
    {
        get
        {
            return FlatCamForward * FollowDir.z + FlatCamRight * FollowDir.x;
        }
    }
    [BoxGroup("WASD")][ShowInInspector][ReadOnly] public Vector3 MoveDirFollow_Global => m_moveDir_follow;

    [BoxGroup("WASD")]
    [ShowInInspector]
    [ReadOnly]
    public float MoveSpeed => m_moveSpeed;

    public void SetMoveDirection(Vector3 dir)
    {
        m_moveDir = dir;
    }
    public void SetRunInput(float value)
    {
        m_runInput = value;
    }
    #endregion
    Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        CalcFlatCamDir();

        m_moveDir_follow = new Vector3(Mathf.Lerp(m_moveDir_follow.x, InputDir_Local.x, m_moveDir_follow_lerp),
            0, Mathf.Lerp(m_moveDir_follow.z, InputDir_Local.z, m_moveDir_follow_lerp));
        if (Vector3.Distance(m_moveDir_follow, InputDir_Local) < 0.1f)
            m_moveDir_follow = InputDir_Local;

        m_lookDir_follow = Vector3.Lerp(m_lookDir_follow, FlatCamForward, m_lookDir_follow_lerp);
        if (Vector3.Distance(m_lookDir_follow, FlatCamForward) < 0.1f)
            m_lookDir_follow = FlatCamForward;
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
}
