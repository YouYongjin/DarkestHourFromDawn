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

    IEnumerator SurpriseEventCO()
    {
        yield return new WaitForSeconds(2f);
        bigBear.SetActive(true);
        lookAtBear = true;
        Loop2.lightList[0].SetActive(true);
        Loop2.lightList[1].SetActive(true);
        Loop2.lightList[2].SetActive(true);
        Loop2.lightList[3].SetActive(true);
        Loop2.lightList[4].SetActive(true);
        yield return new WaitForSeconds(5f);
        lookAtBear = false;

    }

    public void LookAtBear()
    {
        if (!lookAtBear) return;

        pcCamera.transform.LookAt(bigBearT);
    }

    private void Update()
    {
        LookAtBear();
    }

    public void SurpriseOn()
    {
        StartCoroutine(SurpriseEventCO());
    }
}
