using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class None_Door : MonoBehaviour
{
    public Animator anim;
    public AudioSource audioSource;
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
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            frontDoor = false;
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && frontDoor && isDoorOn)
        {
            anim.SetBool("isDoorOn", true);
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[8]);
            isDoorOn = false;
        }

        if (Input.GetKeyUp(KeyCode.E) && frontDoor && !isDoorOn)
        {
            anim.SetBool("isDoorOn", false);
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[8]);
            isDoorOn = true;
        }
    }
}
