using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniCamera : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
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
            anim.SetBool("isWalk", false);
            //audioSource.Stop();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("isWalk", true);

            //timer += Time.deltaTime;
            //if(timer > waitingTime)
            //{

            //SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundCharacter[0]);

            //timer = 0;
            //}
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("isWalk", false);
            //audioSource.Stop();
        }
    }
}
