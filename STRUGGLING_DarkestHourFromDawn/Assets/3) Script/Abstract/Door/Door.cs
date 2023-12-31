using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Door : MonoBehaviour
{
    public Animator anim;

    public bool isOpen = false;
    bool isLock = false;
    bool isSurprise = false;


    //private void Start()
    //{
    //    isOpen = false;
    //    isLock = false;
    //    isSurprise = false;
    //}

    public abstract bool CheckOpen();
    public void Open()
    {
        if(!CheckOpen())
        {
            if (!isLock)
            {
                //anim.SetBool("isLock", true);
                //isLock = true;
                anim.Play("LockDoor");
                return;
            }
            //else if (isLock)
            //{
            //    anim.SetBool("isLock", false);
            //    isLock = false;
            //    return;
            //}
        }

        if(!isOpen)
        {
            anim.Play("OpenDoor");
            isOpen = true;
        }
        else if(isOpen)
        {
            anim.Play("CloseDoor");
            isOpen = false;
        }
    }
}
