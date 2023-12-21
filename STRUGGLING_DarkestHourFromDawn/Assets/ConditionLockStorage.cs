using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionLockStorage : Chiffonier
{
    public Raycast raycast;

    public bool isLocked;
    public LightEventLoop2 lightEventLoop2;
    public GameObject lockCollider;
    public override bool CheckOpen()
    {
        if (raycast.hasCollect_Items[2] && raycast.hasCollect_Items[3] && raycast.hasCollect_Items[4] && raycast.hasCollect_Items[5]) 
        {
            Debug.Log("true");
            return true;
        }
        Debug.Log("false");
        isLocked = false;
        lockCollider.SetActive(isLocked);
        return false;
        //if (!raycast.hasCollect_Items[2]) return !isLocked;
        //if (!raycast.hasCollect_Items[3]) return !isLocked;
        //if (!raycast.hasCollect_Items[4]) return !isLocked;
        //if (!raycast.hasCollect_Items[5]) return !isLocked;
    }
}
