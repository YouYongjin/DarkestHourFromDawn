using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    public AudioSource audioSource;
    public bool lobbyCondition1;

    public void Start()
    {
        lobbyCondition1 = false;
    }
    public void BellSound()
    {
        SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[30]);
        lobbyCondition1 = true;
        //Debug.Log(lobbyCondition1);
    }
}
