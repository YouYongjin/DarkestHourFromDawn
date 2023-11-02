using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEventLoop2 : MonoBehaviour
{
    public GameObject[] lightList;
    public GameObject bigBear;
    public GameObject pcCamera;

    public Transform bigBearT;

    public PlayerV2 player;
    public Flashlight_Switch flashLight;

    float realTime;

    void Start()
    {

    }

    public void LightEvent()
    {
        StartCoroutine(LightEventCO());
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LightEvent();
        }
    }

    // Ư�� ��Ȳ���� ������Ʈ�� ��, �ڷ�ƾ ���
    IEnumerator LightEventCO()
    {
        while (realTime < 7.5)
        {
            realTime += Time.deltaTime;
            if (realTime >= 0.1f)
            {
                flashLight.eIDown = true;
                flashLight.LightOff();
                lightList[0].SetActive(false);
                Debug.Log("����");
            }
            if (realTime >= 0.6f)
            {
                lightList[1].SetActive(false);
            }
            if (realTime >= 1.1f)
            {
                lightList[2].SetActive(false);
            }
            if (realTime >= 1.6f)
            {
                lightList[3].SetActive(false);
            }
            if (realTime >= 2.1f)
            {
                lightList[4].SetActive(false);
            }
            if (realTime >= 6.5f)
            {
                // �� �κ��� �׳� Ư�� �ݶ��̴��� ���� �� ���� �ǵ��� �ϴ� ���� ���?
                //player.moveSpeed = 0;
                //bigBear.SetActive(true);
                //pcCamera.transform.LookAt(bigBearT);
                //lightList[0].SetActive(true);
                //lightList[1].SetActive(true);
                //lightList[2].SetActive(true);
                //lightList[3].SetActive(true);
                //lightList[4].SetActive(true);
            }
            yield return null;
        }
    }
}


//    void Update()
//    {
//        LightEvent();
//    }
//}
