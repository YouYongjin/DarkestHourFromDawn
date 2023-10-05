using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surprise_Door : MonoBehaviour
{
    public AudioSource audioSource;
    public Animator anim;
    public bool frontDoor;
    public bool isDoorOn;
    void Start()
    {
        frontDoor = false;
        isDoorOn = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("isDoorOn", true);
        }
    }
}
