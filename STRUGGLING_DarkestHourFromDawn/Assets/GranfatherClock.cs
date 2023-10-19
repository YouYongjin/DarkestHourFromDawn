using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranfatherClock : MonoBehaviour
{
    public AudioSource audioSource;
    public Animator anim;

    public bool isClock = true;


    void ClockAutoEvent()
    {
        if(isClock)
        {
            anim.SetBool("isClock", false);
            isClock = false;
        }

        if(!isClock)
        {
            anim.SetBool("isClock", true);
            isClock = true;
        }
    }
    //void Update()
    //{
    //    ClockAutoEvent();
    //}
    public void PlayGranfatherClockSound()
    {
        SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[9]);
    }
}
