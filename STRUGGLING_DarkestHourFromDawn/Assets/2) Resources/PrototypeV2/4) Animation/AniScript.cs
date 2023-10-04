using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniScript : MonoBehaviour
{
    public Animator anim;
    public AudioSource audioSource;
    bool frontWalk;
    bool backWalk;
    bool leftWalk;
    bool rightWalk;

    //float timer;
    //int waitingTime;

    public AudioClip playerSound;

    void Start()
    {
        anim = GetComponent<Animator>();
        //playerSound = GetComponent<AudioClip>();
        //timer = 0.0f;
        //waitingTime = 1;
    }
    //void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        Debug.Log("Ground 태그 입니다.");
            
    //    }
    //    //if (collision.gameObject.CompareTag("Ground") && !frontWalk)
    //    //{
    //    //    audioSource.Stop();
    //    //}
    //}
    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        Debug.Log("그라운드 태그입니다.");
    //        //Debug.Log("전진하고 있습니다.");
    //        //SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundCharacter[0]);
    //        //Debug.Log("걷는소리를 출력합니다.");
    //        audioSource.PlayOneShot(SoundManager.instance.dataBase.soundCharacter[0]);
    //    }
    //    if(collision.gameObject.CompareTag("Ground") && !frontWalk)
    //    {
    //        audioSource.Stop();
    //    }
    //}

    //void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag(""))
    //    {
    //        audioSource.PlayOneShot(SoundManager.instance.dataBase.soundCharacter[0]);
    //        Debug.Log("걷는소리를 정지합니다.");
    //    }


    //}
    void Update()
    {
        #region 전면 이동
        if (Input.GetKeyDown(KeyCode.W))
        {
            frontWalk = true;
            anim.SetBool("isWalk", true);

            //timer += Time.deltaTime;
            //if(timer > waitingTime)
            //{
 
                //SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundCharacter[0]);

            //timer = 0;
            //}
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            frontWalk = false;
            anim.SetBool("isWalk", false);
            //audioSource.Stop();
        }
        #endregion

        #region 후면 이동
        if (Input.GetKeyDown(KeyCode.S))
        {
            backWalk = true;
            anim.SetBool("isBackWalk", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            backWalk = false;
            anim.SetBool("isBackWalk", false);
        }
        #endregion

        #region 왼쪽 이동
        if (Input.GetKeyDown(KeyCode.A))
        {
            leftWalk = true;
            anim.SetBool("isLeftWalk", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            leftWalk = false;
            anim.SetBool("isLeftWalk", false);
        }
        #endregion

        #region 오른쪽 이동
        if (Input.GetKeyDown(KeyCode.D))
        {
            rightWalk = true;
            anim.SetBool("isRightWalk", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            rightWalk = false;
            anim.SetBool("isRightWalk", false);
        }
        #endregion

    }
    public void PlayFootSound()
    {
        // 자신의 aduioSource 변수를 변환할 것을 요청, SoundManager의 모든 것을 개입할 수 있는 상태로, dataBase(스크립트 변수) 내에 리스트 변수 soundCharacter[0] 참조 및 저장 요청
        SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundCharacter[0]);
    }
}

