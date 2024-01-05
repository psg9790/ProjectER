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

    void OnJump(InputValue value)
    {
        GetComponent<Player>().Jump();
        GetComponent<Player>().anim.SetBool("Jump", true);
    }

    void OnW(InputValue value)
    {

    }
    void OnA(InputValue value)
    {

    }
    void OnS(InputValue value)
    {

    }
    void OnD(InputValue value)
    {

    }
}
