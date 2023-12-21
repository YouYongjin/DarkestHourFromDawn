using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop2MirrorTrigger : MonoBehaviour
{
    public SurpriseEvent SE;

    public bool check;
    public bool EventOn;
    //public bool check2;

    private void Start()
    {
        check = true;
        EventOn = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("π‚¿Ω");
            if (check)
            {
                if(SE.quest2_1_1)
                {
                    //Debug.Log("EventONNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN");
                    EventOn = true;
                    check = false;
                }
            }
        }
    }
}
