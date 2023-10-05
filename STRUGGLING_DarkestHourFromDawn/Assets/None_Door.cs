using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class None_Door : MonoBehaviour
{
    public Animator anim;
    public bool frontDoor;


    void Start()
    {
        frontDoor = false;

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
        if (Input.GetKeyDown(KeyCode.E) && frontDoor)
        {
            anim.SetBool("isDoorOn", true);
        }

        if (Input.GetKeyUp(KeyCode.E) && frontDoor)
        {
            anim.SetBool("isDoorOn", false);
        }
    }
}
