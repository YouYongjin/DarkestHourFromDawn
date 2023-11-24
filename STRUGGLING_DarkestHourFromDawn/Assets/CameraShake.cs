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

    bool soundCheck = false;

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

    //void ConfusePiece1()
    //{
    //    camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

    //    shakeDuration -= Time.deltaTime * decreaseFactor;
    //}

    //void ConfusePiece2()
    //{
    //    shakeDuration = 0f;
    //    camTransform.localPosition = originalPos;
    //}

    public void Confuse()
    {
        if (CUIM.cameraShakeOn == true)
        {
            if (shakeDuration > 0)
            {
                camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

                shakeDuration -= Time.deltaTime * decreaseFactor;
                soundCheck = true;
                if (soundCheck)
                {
                    SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundCharacter[1]);
                    soundCheck = false;
                }
            }
            else
            {
                camTransform.localPosition = originalPos;
            }
        }
        
    }

    void Update()
    {
        Confuse();
    //    if (shakeDuration > 0)
    //    {
    //        ConfusePiece1();
    //    }
    //    else
    //    {
    //        ConfusePiece2();
    //    }
    }
}
