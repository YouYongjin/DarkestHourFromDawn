using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseEvent : MonoBehaviour
{
    public GameObject bigBear;
    public GameObject pcCamera;

    public Transform bigBearT;

    public PlayerV2 player;
    public LightEventLoop2 Loop2;

    public bool lookAtBear;

    private void Start()
    {
        lookAtBear = false;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SurpriseOn();
        }
    }

    public void SurpriseOn()
    {
        StartCoroutine(SurpriseEventCO());
    }

    IEnumerator SurpriseEventCO()
    {
        yield return new WaitForSeconds(0.1f);
        bigBear.SetActive(true);
        lookAtBear = true;     
        yield return new WaitForSeconds(0.4f);        
        lookAtBear = false;
        Loop2.lightList[0].SetActive(true);
        Loop2.lightList[1].SetActive(true);
        Loop2.lightList[2].SetActive(true);
        Loop2.lightList[3].SetActive(true);
        Loop2.lightList[4].SetActive(true);
    }

    private void Update()
    {
        LookAtBear();

        Debug.Log("이벤트 트리거 상태 : " + lookAtBear);
    }

    public void LookAtBear()
    {
        if (!lookAtBear) return;

        pcCamera.transform.LookAt(bigBearT);
    }
}