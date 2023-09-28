using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniScript : MonoBehaviour
{
    public Animator anim;

    bool Pressed;

    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    void Update()
    {
        #region 전면 이동
        if (Input.GetKeyDown(KeyCode.W))
        {
            Pressed = true;
            anim.SetBool("isWalk", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            Pressed = false;
            anim.SetBool("isWalk", false);
        }
        #endregion

        #region 후면 이동
        if (Input.GetKeyDown(KeyCode.S))
        {
            Pressed = true;
            anim.SetBool("isBackWalk", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Pressed = false;
            anim.SetBool("isBackWalk", false);
        }
        #endregion

        #region 왼쪽 이동
        if (Input.GetKeyDown(KeyCode.A))
        {
            Pressed = true;
            anim.SetBool("isLeftWalk", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Pressed = false;
            anim.SetBool("isLeftWalk", false);
        }
        #endregion

        #region 오른쪽 이동
        if (Input.GetKeyDown(KeyCode.D))
        {
            Pressed = true;
            anim.SetBool("isRightWalk", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Pressed = false;
            anim.SetBool("isRightWalk", false);
        }
        #endregion
    }
}
