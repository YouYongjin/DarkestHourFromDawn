using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueTrigger4 : MonoBehaviour
{
    public CItemUIManager CUM;

    public bool triggerSwitch4 = true;

    private void OnTriggerEnter(Collider other)
    {
        // 열두 번째 독백
        if (other.tag == "Player" && triggerSwitch4 && CUM.conditionOne)
        {
            MonologueUIManager.instance.CallMonologue(0f, 2f, MonologueUIManager.instance.monologueDatabase.triggerUI[3]);
            triggerSwitch4 = false;
        }
    }
}
