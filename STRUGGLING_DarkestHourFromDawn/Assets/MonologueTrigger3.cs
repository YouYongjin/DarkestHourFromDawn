using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueTrigger3 : MonoBehaviour
{
    public CItemUIManager CUM;

    public bool triggerSwitch3 = true;

    private void OnTriggerEnter(Collider other)
    {
        // 열두 번째 독백
        if (other.tag == "Player" && triggerSwitch3 && CUM.conditionOne)
        {
            MonologueUIManager.instance.CallMonologue(0f, 2f, MonologueUIManager.instance.monologueDatabase.triggerUI[2]);
            triggerSwitch3 = false;
        }
    }
}
