using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public Transform camTransform;
    public float shakeDuration = 0f;
    public CItemUIManager CUIM;

    public AudioSource audioSource;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    bool soundCheck = true;

    public bool trigger = false;

    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    public void Confuse()
    {
        if (CUIM.cameraShakeOn == true)
        {
            if (shakeDuration > 0f)
            {
                camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

                shakeDuration -= Time.deltaTime * decreaseFactor;
                if (soundCheck)
                {
                    SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundCharacter[1]);
                    soundCheck = false;
                }
            }
            else
            {
                camTransform.localPosition = originalPos;
                if (shakeDuration <= 0f)
                    shakeDuration = 0f;
            }
        }
        
    }

    void Update()
    {
        Confuse();
    }
}
