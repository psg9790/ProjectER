using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerConfig config;
    private void Start()
    {
        config = GetComponent<PlayerConfig>();
    }

    // void OnMove(InputValue value)
    // {
    //     Vector2 input = value.Get<Vector2>();
    //     config.SetMoveDirection(new Vector3(input.x, 0, input.y));
    // }

    void OnRun(InputValue value)
    {
        config.SetRunInput(value.Get<float>());
    }

    Coroutine jumpBufferCoroutine;
    void OnJump(InputValue value)
    {
        if (jumpBufferCoroutine is null == false)
        {
            StopCoroutine(jumpBufferCoroutine);
        }
        jumpBufferCoroutine = StartCoroutine(JumpBufferCo());
    }
    IEnumerator JumpBufferCo()
    {
        config.SetJumpInput(true);
        yield return new WaitForSeconds(0.15f);
        config.SetJumpInput(false);
    }

    Vector3 moveDir = Vector3.zero;
    float wAmount = 0;
    void OnW(InputValue value)
    {
        if (value.isPressed)
        {
            if (moveDir.z < 0)
            {
                wAmount = -moveDir.z * 2;
                // Debug.Log($"check A {wAmount}");
            }
            else
            {
                wAmount = 1;
                // Debug.Log("start");
            }
            moveDir.z += wAmount;
        }
        else
        {
            moveDir.z -= wAmount;
        }
        config.SetMoveDirection(moveDir);
    }
    float sAmount = 0;
    void OnS(InputValue value)
    {
        if (value.isPressed)
        {
            if (moveDir.z > 0)
            {
                sAmount = -moveDir.z * 2;
                // Debug.Log($"check A {sAmount}");
            }
            else
            {
                sAmount = -1;
                // Debug.Log("start");
            }
            moveDir.z += sAmount;
        }
        else
        {
            moveDir.z -= sAmount;
        }
        config.SetMoveDirection(moveDir);
    }
    float aAmount = 0;
    void OnA(InputValue value)
    {
        if (value.isPressed)
        {
            if (moveDir.x > 0)
            {
                aAmount = -moveDir.x * 2;
                // Debug.Log($"check A {aAmount}");
            }
            else
            {
                aAmount = -1;
                // Debug.Log("start");
            }
            moveDir.x += aAmount;
        }
        else
        {
            moveDir.x -= aAmount;
        }

        config.SetMoveDirection(moveDir);
    }
    float dAmount = 0;
    void OnD(InputValue value)
    {
        if (value.isPressed)
        {
            if (moveDir.x < 0)
            {
                dAmount = -moveDir.x * 2;
                // Debug.Log($"check D {dAmount}");
            }
            else
            {
                dAmount = 1;
                // Debug.Log("start");
            }
            moveDir.x += dAmount;
        }
        else
        {
            moveDir.x -= dAmount;
        }
        config.SetMoveDirection(moveDir);
    }
}
