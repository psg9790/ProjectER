using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Camera cam;
    CharacterController cc;
    PlayerConfig config;
    Animator anim;

    private void Start()
    {
        cam = Camera.main;
        cc = GetComponent<CharacterController>();
        config = GetComponent<PlayerConfig>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        CalcFlatCamDir();

        MoveControl();
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
            anim.SetFloat("Strafe", config.FollowDir.x);
            anim.SetFloat("Forward", config.FollowDir.z);
        }

        cc.Move(config.MoveSpeed * Time.deltaTime * config.MoveDir_Global);
        transform.forward = config.LookDir;
    }
}
