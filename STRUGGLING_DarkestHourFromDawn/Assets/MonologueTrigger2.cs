using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueTrigger2 : MonoBehaviour
{
    public MonologueTrigger1 MonologueTrigger1;
    public bool triggerSwitch2 = true;
    private void OnTriggerEnter(Collider other)
    {
        // 다섯 번째 독백
        if (other.tag == "Player" && triggerSwitch2 && !MonologueTrigger1.triggerSwitch1)
        {
            MonologueUIManager.instance.CallMonologue(0f, 3f, MonologueUIManager.instance.monologueDatabase.triggerUI[1]);
            triggerSwitch2 = false;
        }
    }
}
