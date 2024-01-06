using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Camera cam;
    PlayerConfig config;
    public Animator anim;
    Rigidbody rb;

    private void Start()
    {
        cam = Camera.main;
        config = GetComponent<PlayerConfig>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CalcFlatCamDir();

        //MoveControl();
    }

    void CalcFlatCamDir()
    {
        Vector3 dir = cam.transform.forward;
        dir.y = 0;
        config.SetFlatCamForward(dir);

        dir = cam.transform.right;
        dir.y = 0;
        config.SetFlatCamRight(dir);
    }

    void MoveControl()
    {
        // Debug.Log($"{config.MoveDir_Global.sqrMagnitude} / {config.MoveDirFollow_Global.sqrMagnitude}");
        if (config.InputDir_Local.sqrMagnitude < 0.3f /*&& config.MoveDirFollow_Global.sqrMagnitude < 0.3f*/)
        {
            anim.SetBool("Move", false);
        }
        else
        {
            anim.SetBool("Move", true);
            anim.SetFloat("Strafe", config.InputDirFollow.x);
            anim.SetFloat("Forward", config.InputDirFollow.z);
        }

        transform.position += config.MoveSpeed * Time.deltaTime * config.MoveDir_Global;
        transform.forward = config.LookDir;
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        anim.SetBool("Jump", false);
    }
}
