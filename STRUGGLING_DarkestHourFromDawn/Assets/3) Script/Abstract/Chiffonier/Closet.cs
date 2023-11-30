using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Closet : MonoBehaviour
{
    public Animator anim;

    public bool isOpen = false;
    bool isLock = false;

    public abstract bool ClosetPosition();

    public void Open()
    {
        if (!ClosetPosition())
        {
            if (!isLock)
            {
                //anim.SetBool("isLock", true);
                //isLock = true;
                anim.Play("RightClosetOpen");
                return;
            }
            //else if (isLock)
            //{
            //    anim.SetBool("isLock", false);
            //    isLock = false;
            //    return;
            //}
        }

        if (!isOpen)
        {
            anim.Play("LeftClosetOn");
            isOpen = true;
        }
        else if (isOpen)
        {
            anim.Play("LeftClosetOff");
            isOpen = false;
        }
    }
}
