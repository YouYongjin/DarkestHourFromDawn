using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueTriggerEvent : MonoBehaviour
{

    public GameObject nn1;
    public GameObject nn2;

    private void OnTriggerEnter(Collider other)
    {
        TriggerEvent(other.tag);
    }

    private void TriggerEvent(string _tag)
    {
        switch(_tag)
        {
            case "Player":

                break;
        }
    }
}
