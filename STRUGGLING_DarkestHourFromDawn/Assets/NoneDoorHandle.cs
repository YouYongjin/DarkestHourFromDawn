using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoneDoorHandle : MonoBehaviour
{
    public AudioSource audioSource;
    public void PlayNoneDoorSound()
    {
        SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[8]);
    }
}
