using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftClosetOpen : Closet
{
    //bool Closet = false;
    public override bool ClosetPosition()
    {
        Debug.Log("���� ������ ����");
        return true;
    }
}
