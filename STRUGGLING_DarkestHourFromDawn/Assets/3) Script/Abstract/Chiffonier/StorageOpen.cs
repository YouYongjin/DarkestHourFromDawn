using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageOpen : Chiffonier
{
    public override bool CheckOpen()
    {
        Debug.Log("������ ����");
        return true;
    }
}
