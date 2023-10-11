using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorV2 : MonoBehaviour
{
    public Animator anim;
    public AudioSource audioSource;
    //bool isDoorOn = false;
    public Raycast ray;

    public void DoorOnEvent()
    {
        if (ray.isDoorOn)
        {
            anim.SetBool("isDoorOn", false);
            ray.isDoorOn = false;
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[4]);
        }

        else if (!ray.isDoorOn)
        {
            anim.SetBool("isDoorOn", true);
            ray.isDoorOn = true;
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[4]);
        }
    }
}
