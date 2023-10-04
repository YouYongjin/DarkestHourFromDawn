using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soui : MonoBehaviour
{
    public AudioSource audioSource;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundCharacter[0]);
        }
    }

    void OnTriggerExit(Collider other)
    {
            audioSource.Stop();
    }
}
