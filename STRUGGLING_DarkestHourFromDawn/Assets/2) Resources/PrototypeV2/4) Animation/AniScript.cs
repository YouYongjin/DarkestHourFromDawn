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

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground") && frontWalk)
    //    {
    //        Debug.Log("�±׸� �����߰�, frontWalk = true �Դϴ�.");
    //        SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundCharacter[0]);
    //    }
    //    if (collision.gameObject.CompareTag("Ground") && !frontWalk)
    //    {
    //        audioSource.Stop();
    //    }
    //}
    void Update()
    {
        #region ���� �̵�
        if (Input.GetKeyDown(KeyCode.W))
        {
            frontWalk = true;
            anim.SetBool("isWalk", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            frontWalk = false;
            anim.SetBool("isWalk", false);
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
}
