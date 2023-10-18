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
        }

        else if (!isChiffonierOn)
        {
            anim.SetBool("isChiffonierOn", true);
            isChiffonierOn = true;
        }
    }

    public void PlayStorageSound()
    {
        if (isChiffonierOn || !isChiffonierOn)
        {
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[6]);
        }
    }
}
