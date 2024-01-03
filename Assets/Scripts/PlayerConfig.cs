using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig : MonoBehaviour
{
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

    private Vector3 m_moveDir;
    public Vector3 MoveDir
    {
        get
        {
            Vector3 ret = FlatCamForward * m_moveDir.z + FlatCamRight * m_moveDir.x;
            return ret.normalized;
        }
    }
    public Vector3 InputDir
    {
        get
        {
            return m_moveDir.normalized;
        }
    }

    private float m_moveSpeed = 4f;
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
}
