using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEventLoop2 : MonoBehaviour
{
    public GameObject[] lightList;

    public Flashlight_Switch flashLight;

    public bool SurpriseOn;
    public bool test;
    public bool lightEventOn;

    bool triggerOn = true;

    public float realTime;

    void Start()
    {
        SurpriseOn = false;
        test = false;
        lightEventOn = false;
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
        lightEventOn = true;
    }

    private void Update()
    {
        FlashlightEvent();
    }
}