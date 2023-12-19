using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRabbitDoll : MonoBehaviour
{
    public AudioSource audioSource;
    public bool lobbyCondition2;
    public void DollSound()
    {
        SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[31]);
        lobbyCondition2 = true;
    }
}
