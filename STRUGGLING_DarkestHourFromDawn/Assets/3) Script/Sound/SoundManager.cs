using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    void Awake()
    {
        // 싱글톤 (현재 형태): 모든 곳을 개입할 수 있다.
        instance = this;
    }

        // Sound_DataBase Class를 변수로 갖는다.
    public Sound_DataBase dataBase;

    // 매개 변수: 자신의 AudioSource를 변수 형태의 source로, AudioClip를 clip로 생성한다.
    public void PlayAudioSource(AudioSource source, AudioClip clip)
    {
        // 매개변수 source(AudioSource)의 clip변수는 clip 매개변수이다.
        source.clip = clip;
        // 사운드를 실행시킨다.
        source.Play();
    }
}
