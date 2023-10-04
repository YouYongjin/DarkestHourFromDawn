using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterSwitch : MonoBehaviour
{
    public GameObject triggerResult;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerResult.SetActive(true);
        }
    }
}
