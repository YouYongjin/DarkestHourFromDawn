using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseSound : MonoBehaviour
{
    public AudioSource audioSource;
    public void PlaySurpriseSound()
    {
        SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[5]);
    }
}
