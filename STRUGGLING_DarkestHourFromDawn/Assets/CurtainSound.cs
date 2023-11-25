using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainSound : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayStorageSound()
    {
        SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[6]);
    }
}
