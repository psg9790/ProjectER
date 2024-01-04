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

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        config.SetMoveDirection(new Vector3(input.x, 0, input.y));
    }

    void OnRun(InputValue value)
    {
        // Debug.Log(value.Get<float>());
        config.SetRunInput(value.Get<float>());
    }
}
