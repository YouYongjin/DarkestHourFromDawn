using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator anim;
    public bool frontDoor;
    public bool isDoorOn;
    void Start()
    {
        frontDoor = false;
        isDoorOn = true;
    }
        void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            frontDoor = true;            
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && frontDoor && isDoorOn)
        {
            anim.SetBool("isDoorOn", true);
            isDoorOn = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && frontDoor && !isDoorOn)
        {
            anim.SetBool("isDoorOn", false);
            isDoorOn = true;
        }
    }
}
