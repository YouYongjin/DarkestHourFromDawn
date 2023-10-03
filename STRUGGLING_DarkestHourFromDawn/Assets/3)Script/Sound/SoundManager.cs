using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    void Awake()
    {
        instance = this;
    }

    public Sound_DataBase dataBase;

    public void PlayAudioSource(AudioSource source, AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
