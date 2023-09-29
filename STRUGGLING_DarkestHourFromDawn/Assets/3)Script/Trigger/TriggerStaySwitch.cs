using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStaySwitch : MonoBehaviour
{
    public GameObject triggerResult;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerResult.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerResult.SetActive(false);
        }
    }
}
