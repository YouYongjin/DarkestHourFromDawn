using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    void Awake()
    {
        // �̱��� (���� ����): ��� ���� ������ �� �ִ�.
        instance = this;
    }

        // Sound_DataBase Class�� ������ ���´�.
    public Sound_DataBase dataBase;

    // �Ű� ����: �ڽ��� AudioSource�� ���� ������ source��, AudioClip�� clip�� �����Ѵ�.
    public void PlayAudioSource(AudioSource source, AudioClip clip)
    {
        // �Ű����� source(AudioSource)�� clip������ clip �Ű������̴�.
        source.clip = clip;
        // ���带 �����Ų��.
        source.Play();
    }
}
