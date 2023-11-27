using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClosetOpen : Closet
{
    public override bool ClosetPosition()
    {
        Debug.Log("오른쪽 서랍장 열기");
        return true;
    }
}
