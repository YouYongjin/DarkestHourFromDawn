using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetSound : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayClosetOnSound()
    {
        SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[15]);
    }
    public void PlayClosetOffSound()
    {
        SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[15]);
    }
}
