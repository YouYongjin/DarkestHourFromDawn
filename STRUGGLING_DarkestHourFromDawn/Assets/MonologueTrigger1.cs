using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueTrigger1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            MonologueUIManager.instance.CallMonologue(0f, 1.5f, MonologueUIManager.instance.monologueDatabase.monologueUI[2]);
        }
    }
}