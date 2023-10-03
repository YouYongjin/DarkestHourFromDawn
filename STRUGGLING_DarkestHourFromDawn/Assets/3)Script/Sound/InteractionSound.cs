using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSound : MonoBehaviour
// 인터랙션시, 오디오 클립을 재생하는 스크립트
{
    public AudioSource audioSource;
    public bool isTriggered; 
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
            isTriggered = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isTriggered = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isTriggered)
        {
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[0]);
        }
    }
}
