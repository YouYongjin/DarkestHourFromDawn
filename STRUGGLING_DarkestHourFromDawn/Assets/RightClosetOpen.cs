using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClosetOpen : Closet
{
    public override bool ClosetPosition()
    {
        Debug.Log("������ ������ ����");
        return true;
    }
}
