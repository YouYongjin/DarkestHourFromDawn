using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseEvent : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource mirrorBrokenAudio;

    public GameObject bigBear;
    public GameObject pcCamera;
    public GameObject bigBearLight;

    public GameObject[] mirrorPiece;
    public GameObject mirrorDefault;
    public GameObject mirrorCountObj;

    public Transform bigBearT;

    public PlayerV2 player;
    public LightEventLoop2 Loop2;

    public bool lookAtBear;

    bool triggerOn = true;

    private void Start()
    {
        lookAtBear = false;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && triggerOn)
        {
            SurpriseOn();
            triggerOn = false;
        }
    }

    public void SurpriseOn()
    {
        StartCoroutine(SurpriseEventCO());
    }

    IEnumerator SurpriseEventCO()
    {
        yield return new WaitForSeconds(0.1f);
        bigBear.SetActive(true);
        SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[21]);
        lookAtBear = true;     
        yield return new WaitForSeconds(0.5f);
        mirrorCountObj.SetActive(true);
        lookAtBear = false;
        bigBearLight.SetActive(false);

        Loop2.lightList[0].SetActive(true);
        Loop2.lightList[1].SetActive(true);
        Loop2.lightList[2].SetActive(true);
        Loop2.lightList[3].SetActive(true);
        Loop2.lightList[4].SetActive(true);

        mirrorPiece[0].SetActive(true);
        mirrorPiece[1].SetActive(true);
        mirrorPiece[2].SetActive(true);
        mirrorPiece[3].SetActive(true);
        mirrorDefault.SetActive(false);

        SoundManager.instance.PlayAudioSource(mirrorBrokenAudio, SoundManager.instance.dataBase.soundEffect[26]);

    }

    private void Update()
    {
        LookAtBear();

        Debug.Log("이벤트 트리거 상태 : " + lookAtBear);
    }

    public void LookAtBear()
    {
        if (!lookAtBear) return;

        pcCamera.transform.LookAt(bigBearT);
    }
}