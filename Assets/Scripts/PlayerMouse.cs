using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using Sirenix.OdinInspector;

public class PlayerMouse : MonoBehaviour
{
    Camera mainCam;
    Vector2 inputDir;
    Vector3 moveDir;
    [SerializeField] float moveSpeed = 5f;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        Vector3 dir = mainCam.transform.right * inputDir.x + mainCam.transform.forward * inputDir.y;
        dir.y = 0;
        dir.Normalize();

        moveDir = dir;

        transform.position = transform.position + Time.deltaTime * moveSpeed * moveDir;
        if (moveDir != Vector3.zero)
            transform.forward = moveDir;
    }

    void OnMove(InputValue input)
    {
        inputDir = input.Get<Vector2>();
    }
}
