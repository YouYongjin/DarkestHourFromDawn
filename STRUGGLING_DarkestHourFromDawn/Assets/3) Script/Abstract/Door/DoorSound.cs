using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public AudioSource audioSource;
    public void OpenSound()
    {
        SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[4]);
    }

    public void LockSound()
    {
        SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[8]);
    }

    public void SurpriseSound()
    {
        SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[5]);
    }
}
