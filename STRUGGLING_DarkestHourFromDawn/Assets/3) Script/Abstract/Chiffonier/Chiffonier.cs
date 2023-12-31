using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Chiffonier : MonoBehaviour
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
                //anim.SetBool("isLock", true);
                //isLock = true;
                anim.Play("StorageLock");
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
            anim.Play("StorageOn");
            isOpen = true;
        }
        else if (isOpen)
        {
            anim.Play("StorageOff");
            isOpen = false;
        }
    }
}
