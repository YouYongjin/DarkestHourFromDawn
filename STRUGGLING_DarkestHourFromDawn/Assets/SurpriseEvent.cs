using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseEvent : MonoBehaviour
{
    public LightEventLoop2 Loop2;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.moveSpeed = 0;
            bigBear.SetActive(true);
            pcCamera.transform.LookAt(bigBearT);
            lightList[0].SetActive(true);
            lightList[1].SetActive(true);
            lightList[2].SetActive(true);
            lightList[3].SetActive(true);
            lightList[4].SetActive(true);
        }

    }
}
