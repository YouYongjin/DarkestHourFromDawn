using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surprise_Doll : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject triggerCollider;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerCollider.gameObject.SetActive(true);
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[7]);
        }
    }
}
