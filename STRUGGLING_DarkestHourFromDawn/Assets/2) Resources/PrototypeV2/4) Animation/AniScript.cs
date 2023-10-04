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
    //        Debug.Log("Ground �±� �Դϴ�.");
            
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
    //        Debug.Log("�׶��� �±��Դϴ�.");
    //        //Debug.Log("�����ϰ� �ֽ��ϴ�.");
    //        //SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundCharacter[0]);
    //        //Debug.Log("�ȴ¼Ҹ��� ����մϴ�.");
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
    //        Debug.Log("�ȴ¼Ҹ��� �����մϴ�.");
    //    }


    //}
    void Update()
    {
        #region ���� �̵�
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

        #region �ĸ� �̵�
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

        #region ���� �̵�
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

        #region ������ �̵�
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
        // �ڽ��� aduioSource ������ ��ȯ�� ���� ��û, SoundManager�� ��� ���� ������ �� �ִ� ���·�, dataBase(��ũ��Ʈ ����) ���� ����Ʈ ���� soundCharacter[0] ���� �� ���� ��û
        SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundCharacter[0]);
    }
}

