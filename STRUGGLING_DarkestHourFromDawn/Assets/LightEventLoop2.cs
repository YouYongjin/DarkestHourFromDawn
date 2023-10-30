using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEventLoop2 : MonoBehaviour
{
    public GameObject[] lightList;

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

    // 특정 상황에서 업데이트할 때, 코루틴 사용
    IEnumerator LightEventCO()
    {
        while (realTime < 5.1)
        {
            realTime += Time.deltaTime;
            if (realTime >= 0.1f)
            {
                lightList[0].SetActive(false);
                Debug.Log("실행");
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
                realTime = 0f;
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
