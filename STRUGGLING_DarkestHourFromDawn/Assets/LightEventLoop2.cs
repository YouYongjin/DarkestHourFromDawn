using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEventLoop2 : MonoBehaviour
{
    public GameObject[] lightList;
    //public GameObject bigBear;
    //public GameObject pcCamera;

    //public Transform bigBearT;

    //public PlayerV2 player;
    public Flashlight_Switch flashLight;

    public bool SurpriseOn;
    public bool test;

    bool triggerOn = true;

    public float realTime;

    void Start()
    {
        SurpriseOn = false;
        test = false;
    }

    public void LightEvent()
    {
        StartCoroutine(LightEventCO());
    }

    public void FlashlightEvent()
    {
        if (!test) return;
        if (SurpriseOn) return;
        
        flashLight.eIDown = false;
        flashLight.LightOff();        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && triggerOn)
        {
            LightEvent();
            triggerOn = false;
        }
    }

    // 특정 상황에서 업데이트할 때, 코루틴 사용
    IEnumerator LightEventCO()
    {
        yield return new WaitForSeconds(0.1f);
        lightList[0].SetActive(false);
        test = true;
        Debug.Log("실행");
        yield return new WaitForSeconds(0.6f);
        lightList[1].SetActive(false);
        yield return new WaitForSeconds(1.1f);
        lightList[2].SetActive(false);
        yield return new WaitForSeconds(1.6f);
        lightList[3].SetActive(false);
        lightList[4].SetActive(false);
        yield return new WaitForSeconds(2.1f);
        test = false;

        //yield return null;

        //while (realTime < 7.5)
        //{
        //    realTime += Time.deltaTime;
        //    if (realTime >= 0.1f)
        //    {
        //        flashLight.eIDown = true;
        //        flashLight.LightOff();
        //        lightList[0].SetActive(false);
        //        Debug.Log("실행");
        //    }
        //    if (realTime >= 0.6f)
        //    {
        //        lightList[1].SetActive(false);
        //    }
        //    if (realTime >= 1.1f)
        //    {
        //        lightList[2].SetActive(false);
        //    }
        //    if (realTime >= 1.6f)
        //    {
        //        lightList[3].SetActive(false);
        //    }
        //    if (realTime >= 2.1f)
        //    {
        //        lightList[4].SetActive(false);
        //    }
        //    if (realTime >= 6.5f)
        //    {
        // 이 부분은 그냥 특정 콜라이더를 밟을 때 실행 되도록 하는 것은 어떤가?
        //player.moveSpeed = 0;
        //bigBear.SetActive(true);
        //pcCamera.transform.LookAt(bigBearT);
        //lightList[0].SetActive(true);
        //lightList[1].SetActive(true);
        //lightList[2].SetActive(true);
        //lightList[3].SetActive(true);
        //lightList[4].SetActive(true);
        //}
        //yield return null;
        //}
    }

    private void Update()
    {
        FlashlightEvent();
    }
}


//    void Update()
//    {
//        LightEvent();
//    }
//}
