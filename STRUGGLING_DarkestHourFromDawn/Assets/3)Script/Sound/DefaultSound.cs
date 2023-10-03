using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSound : MonoBehaviour
{
    public AudioSource audioSource;
    void Start()
    {
        SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundBGM[0]);
    }
}
