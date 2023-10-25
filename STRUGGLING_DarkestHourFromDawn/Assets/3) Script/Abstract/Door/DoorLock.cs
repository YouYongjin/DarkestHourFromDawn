using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : Door
{
    public bool isLocked;
    public override bool CheckOpen()
    {
        return !isLocked;
    }
}
