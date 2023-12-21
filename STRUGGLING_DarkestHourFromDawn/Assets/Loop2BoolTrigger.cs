using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop2BoolTrigger : MonoBehaviour
{
    public bool trigger = true;

     void OnTriggerEnter(Collider other)
     {
        if(trigger)
        {
            trigger = false;
        }
     }

}
