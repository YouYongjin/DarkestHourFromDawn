using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surprise_DoorV2 : MonoBehaviour
{
    public AudioSource audioSource;
    public Animator anim;
    public GameObject lights;

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
            anim.SetBool("isSurpriseOn", true);
            Destroy(lights);
        }
    }
}
