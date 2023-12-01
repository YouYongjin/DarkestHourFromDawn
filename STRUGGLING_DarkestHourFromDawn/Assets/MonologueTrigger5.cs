using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueTrigger5 : MonoBehaviour
{
    public bool triggerSwitch5 = true;
    public bool triggerSwitch6 = true;

    // 로비 첫 번째 독백
    private void OnTriggerEnter(Collider other)
    {
        // 열두 번째 독백
        if (other.tag == "Player")
        {
            if (triggerSwitch5)
            {
                MonologueUIManager.instance.CallMonologue(0f, 2f, MonologueUIManager.instance.monologueDatabase.lobbyUI[1]);
                triggerSwitch5 = false;
            }
            if (triggerSwitch6)
            {
                MonologueUIManager.instance.CallMonologue(2.55f, 2.25f, MonologueUIManager.instance.monologueDatabase.lobbyUI[2]);
                triggerSwitch6 = false;
            }
        }
    }
}
