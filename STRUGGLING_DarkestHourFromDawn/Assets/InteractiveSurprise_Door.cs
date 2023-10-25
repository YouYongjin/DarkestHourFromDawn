using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveSurprise_Door : MonoBehaviour
{
    public Raycast raycast;
    public SceneEventManager sem;
    public Animator anim;

    public bool isSDoorOn;
    //bool[] hasE;
    //bool[] hasC;

    //int cItemIndex = 1;
    //int eItemIndex = 0;

    //void Start()
    //{
    //    hasE = raycast.hasEquip_Items;
    //    hasC = raycast.hasCollect_Items;
    //}

    //public GameObject lightObj;
    //public void GetCItem1()
    //{
    //    GameManager.instance.TestEvent(hasE, hasC, eItemIndex, cItemIndex, lightObj);
    //}

    //public void SurpriseDoorEvent()
    //{
    //    if (!isSDoorOn)
    //    {
    //        anim.SetBool("isDoorOpen", true);
    //        anim.SetBool("isDoorClose", false);
    //        isSDoorOn = true;
    //    }
    //    else if (isSDoorOn)
    //    {
    //        anim.SetBool("isDoorOpen", false);
    //        anim.SetBool("isDoorClose", true);
    //        isSDoorOn = false;
    //    }
    //}

    //public void SceneLoop2()
    //{
    //    if (sem.isLoop1On)
    //    {
    //        Debug.Log("애니메이션 실행");
    //        anim.SetBool("isDoorSurprise", true);
    //    }
    //}

    private void Start()
    {
        isSDoorOn = false;
    }

    private void Update()
    {
        //SceneLoop2();
    }
}
