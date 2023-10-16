using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChiffonierV2 : MonoBehaviour
{
    public Animator anim;
    public AudioSource audioSource;
    public bool isChiffonierOn = false;

    public void StorageOnEvent()
    {
        if (isChiffonierOn)
        {
            anim.SetBool("isChiffonierOn", false) ;
            isChiffonierOn = false;
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[6]);
        }

        else if (!isChiffonierOn)
        {
            anim.SetBool("isChiffonierOn", true);
            isChiffonierOn = true;
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[6]);
        }
    }
}
