using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureChiffonier : MonoBehaviour
{
    public AudioSource audioSource;
    public Animator anim;
    public bool frontDoor;
    public bool isChiffonierOn;
    void Start()
    {
        frontDoor = false;
        isChiffonierOn = true;
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
        if (Input.GetKeyDown(KeyCode.E) && frontDoor && isChiffonierOn)
        {
            anim.SetBool("isChiffonierOn", true);
            isChiffonierOn = false;
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[6]);
        }
        else if (Input.GetKeyDown(KeyCode.E) && frontDoor && !isChiffonierOn)
        {
            anim.SetBool("isChiffonierOn", false);
            isChiffonierOn = true;
        }
    }
}
