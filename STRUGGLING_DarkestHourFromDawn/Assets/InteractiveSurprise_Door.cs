using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveSurprise_Door : MonoBehaviour
{
    public Raycast raycast;
    bool[] hasE;
    bool[] hasC;

    int cItemIndex = 1;
    int eItemIndex = 0;

    void Start()
    {
        hasE = raycast.hasEquip_Items;
        hasC = raycast.hasCollect_Items;
    }

    public GameObject lightObj;
    public void GetCItem1()
    {
        GameManager.instance.TestEvent(hasE, hasC, eItemIndex, cItemIndex, lightObj);
    }
}
