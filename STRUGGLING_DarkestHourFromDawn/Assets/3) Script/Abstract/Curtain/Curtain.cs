using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Curtain : MonoBehaviour
{
    public Animator anim;

    public bool isOpen = false;
    bool isLock = false;

    public abstract bool CheckOpen();

    public void Open()
    {
        if (!CheckOpen())
        {
            if (!isLock)
            {
                anim.Play("New State");
                return;
            }
        }

        if (!isOpen)
        {
            anim.Play("CurtainOn");
            isOpen = true;
        }
        else if (isOpen)
        {
            anim.Play("CurtainOff");
            isOpen = false;
        }
    }
}
