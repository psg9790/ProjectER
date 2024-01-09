using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [Header("Boxcast Property")]
    [SerializeField] private Vector3 boxSize;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask groundLayer;

    [Header("Debug")]
    [SerializeField] private bool drawGizmo;

    [ShowInInspector][ReadOnly] public bool IS_GROUNDED => IsGrounded();

    private void OnDrawGizmos()
    {
        if (!drawGizmo) return;

        Gizmos.color = Color.cyan;
        Gizmos.DrawCube(transform.position - transform.up * maxDistance, boxSize);
    }

    public bool IsGrounded()
    {
        // return Physics.BoxCast(transform.position, boxSize, -transform.up, transform.rotation, maxDistance, groundLayer);
        RaycastHit[] hits = Physics.BoxCastAll(transform.position, boxSize, -transform.up, transform.rotation, maxDistance, groundLayer);
        return hits.Length > 0 ? true : false;
    }
}

// https://velog.io/@nagi0101/Unity-%EC%99%84%EB%B2%BD%ED%95%9C-CharacterController-%EA%B8%B0%EB%B0%98-Player%EB%A5%BC-%EC%9C%84%ED%95%B4