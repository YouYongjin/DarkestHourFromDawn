using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surprise_Doll : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject triggerCollider;
    public bool isSurrprise;

    public void Start()
    {
        isSurrprise = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isSurrprise)
        {
            triggerCollider.gameObject.SetActive(true);
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[7]);
            isSurrprise = false;
        }
    }
}
