using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorV2 : MonoBehaviour
{
    public Animator anim;
    public AudioSource audioSource;
    //bool isDoorOn = false;
    public bool isDoorOn = false;

    public void DoorOnEvent()
    {
        if (isDoorOn)
        {
            anim.SetBool("isDoorOn", false);
            isDoorOn = false;
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[4]);
        }

        else if (!isDoorOn)
        {
            anim.SetBool("isDoorOn", true);
            isDoorOn = true;
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[4]);
        }
    }
}
