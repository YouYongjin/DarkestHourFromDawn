using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
   public AudioSource audioSource;
    public bool isTriggered;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundBGM[2]);
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = false;
            audioSource.Stop();
        }
    }
}
