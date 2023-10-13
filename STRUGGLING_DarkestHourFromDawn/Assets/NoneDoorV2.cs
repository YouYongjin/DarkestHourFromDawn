using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoneDoorV2 : MonoBehaviour
{
    public Animator anim;
    public AudioSource audioSource;
    //bool isDoorOn = false;
    public bool isDoorOff = false;

    public void DoorOffEvent()
    {
        if (isDoorOff)
        {
            anim.SetBool("isDoorOff", false);
            isDoorOff = false;
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[8]);

        }

        else if (!isDoorOff)
        {
            anim.SetBool("isDoorOff", true);
            isDoorOff = true;
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[8]);
        }
    }
}
