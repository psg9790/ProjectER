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
    [SerializeField] Animator anim;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        Vector3 camDir = mainCam.transform.forward;
        camDir.y = 0;
        camDir.Normalize();

        Vector3 dir = mainCam.transform.right * inputDir.x + mainCam.transform.forward * inputDir.y;
        dir.y = 0;
        dir.Normalize();

        moveDir = dir;
        anim.SetFloat("Strafe", inputDir.x);
        anim.SetFloat("Forward", inputDir.y);

        transform.position = transform.position + Time.deltaTime * moveSpeed * moveDir;
        transform.forward = camDir;
    }

    void OnMove(InputValue input)
    {
        inputDir = input.Get<Vector2>();
    }
}
