using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using Sirenix.OdinInspector;

public class PlayerMouse : MonoBehaviour
{
    Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
    }

    void OnMove(InputValue input)
    {
        Vector2 inputDir = input.Get<Vector2>();

        Vector3 dir = mainCam.transform.right * inputDir.x + mainCam.transform.forward * inputDir.y;
        dir.y = 0;
        dir.Normalize();

        if (inputDir.magnitude != 0)
            transform.forward = dir;
        transform.position = transform.position + dir;
    }
}
