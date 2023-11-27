using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetSurprise : MonoBehaviour
{
    public Animator animDoll;
    public Animator animCloset;

    bool oneShot = true;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && oneShot)
        {
            animDoll.Play("SurpriseDoll");
            animCloset.Play("ClosetLittleOff");
            oneShot = false;
        }
    }
}
