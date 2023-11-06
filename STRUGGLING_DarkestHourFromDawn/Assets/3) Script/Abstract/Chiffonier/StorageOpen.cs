using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageOpen : Chiffonier
{
    public override bool CheckOpen()
    {
        Debug.Log("서랍장 열기");
        return true;
    }
}
