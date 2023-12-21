using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shower : MonoBehaviour
{
    public AudioSource audioSource;
    void Start()
    {
        ShowerSound();
    }
    void ShowerSound()
    {
        SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[14]);
    }
}
