using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageLock : Chiffonier
{
    public bool isLocked;
    public override bool CheckOpen()
    {
        return !isLocked;
    }
}
