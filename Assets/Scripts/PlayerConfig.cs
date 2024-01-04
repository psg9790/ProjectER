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
    private float m_moveSpeed = 4f;

    private Vector3 follow_moveDir;
    private float follow_moveDir_lerp = 0.05f;

    [BoxGroup("WASD")]
    [ShowInInspector]
    [ReadOnly]
    public Vector3 FollowDir
    {
        get
        {
            follow_moveDir = new Vector3(Mathf.Lerp(follow_moveDir.x, m_moveDir.x, follow_moveDir_lerp),
            0, Mathf.Lerp(follow_moveDir.z, m_moveDir.z, follow_moveDir_lerp));

            return follow_moveDir;
        }
    }
    [BoxGroup("WASD")]
    [ShowInInspector]
    [ReadOnly]
    public Vector3 InputDir
    {
        get
        {

            return m_moveDir.normalized;
        }
    }
    [BoxGroup("WASD")]
    [ShowInInspector]
    [ReadOnly]
    public Vector3 MoveDir
    {
        get
        {
            Vector3 ret = FlatCamForward * m_moveDir.z + FlatCamRight * m_moveDir.x;
            return ret.normalized;
        }
    }
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

    public void SetMoveDirection(Vector3 dir)
    {
        m_moveDir = dir;
    }
    #endregion

}
