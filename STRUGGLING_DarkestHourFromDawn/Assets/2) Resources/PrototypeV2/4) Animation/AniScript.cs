using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniScript : MonoBehaviour
{
    public Animator anim;

    //bool Pressed;

    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    void Update()
    {
        #region 전진 애니메이션 
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Pressed = true;
            anim.SetTrigger("Walk");
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            //Pressed = false;
            anim.SetTrigger("Walk");
        }
        #endregion

        #region 후진 애니메이션 
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Pressed = true;
            anim.SetTrigger("BackWalk");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            //Pressed = false;
            anim.SetTrigger("BackWalk");
        }
        #endregion

    }
}
