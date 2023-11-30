using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueTrigger1 : MonoBehaviour
{
    public bool triggerSwitch1 = true;
    private void OnTriggerEnter(Collider other)
    {
        // 세 번째 독백
        if(other.tag == "Player" && triggerSwitch1)
        {
            MonologueUIManager.instance.CallMonologue(0f, 2f, MonologueUIManager.instance.monologueDatabase.triggerUI[0]);
            triggerSwitch1 = false;
        }
    }
}