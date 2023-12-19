using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestUIManager : MonoBehaviour
{
    public Raycast raycast;
    public CItemUIManager CUM;
    public GameLoading GL;
    public Bell bell;
    public BigRabbitDoll BRD;
    public MonologueTrigger1 MT1;
    public Flashlight_Switch flashlight;

    public GameObject main;
    public GameObject lobbyQuestList;
    public GameObject loop1_1QuestList;
    public GameObject loop1_2QuestList;
    public GameObject loop2QuestList;


    public GameObject checkCondition1;
    public GameObject checkCondition2;
    public GameObject checkCondition3;

    public AudioSource audioSource;

    public bool aimCheck1;
    public bool aimCheck2_1;
    public bool aimCheck2_2;
    public bool aimCheck3;

    public bool conditionCheck1 = false;
    public bool conditionCheck2 = false;
    public bool conditionCheck3 = false;


    void Awake()
    {
        aimCheck1 = true;
        aimCheck2_1 = true;
        aimCheck2_2 = true;
        aimCheck3 = true;
        //Interaction = flashlight.eIDown;
    }

    void Flashlight()
    {
        Interaction = flashlight.eIDown;
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            lobbyQuestList.SetActive(true);
        }

        else if (SceneManager.GetActiveScene().name == "Loop1")
        {
            loop1_1QuestList.SetActive(true);
            checkCondition3.SetActive(false);

        }

        else if (SceneManager.GetActiveScene().name == "Loop2")
        {
            loop2QuestList.SetActive(true);
        }

    }


    void Update()
    {
        Condition();
        Flashlight();
        //PencilSound();
        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            if (CUM.isFunction4)
            {
                main.SetActive(true);
                if (aimCheck1)
                {
                    SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundBGM[12]);
                    aimCheck1 = false;
                }
            }
        }
        else if (SceneManager.GetActiveScene().name == "Loop1")
        {
            main.SetActive(true);
            if (aimCheck2_1)
            {
                SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundBGM[12]);
                aimCheck2_1 = false;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Loop2")
        {
            main.SetActive(true);
            if (aimCheck3)
            {
                SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundBGM[12]);
                aimCheck3 = false;
            }
        }
    }
    bool color1 = true;
    bool color2 = true;
    bool color3 = true;
    void ColorImage1()
    {
        Color color = checkCondition1.GetComponent<Image>().color;
        color.r = 1f;
        color.g = 1f;
        color.b = 0f;

        checkCondition1.GetComponent<Image>().color = color;
        if (color1)
        {
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundBGM[13]);
            color1 = false;
        }
    }
    void ColorImage2()
    {
        Color color = checkCondition2.GetComponent<Image>().color;
        color.r = 1f;
        color.g = 1f;
        color.b = 0f;

        checkCondition2.GetComponent<Image>().color = color;
        if (color2)
        {
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundBGM[13]);
            color2 = false;
        }
    }
    void ColorImage3()
    {
        Color color = checkCondition3.GetComponent<Image>().color;
        color.r = 1f;
        color.g = 1f;
        color.b = 0f;

        checkCondition3.GetComponent<Image>().color = color;
        if (color3)
        {
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundBGM[13]);
            color3 = false;
        }
    }

    void NoneImage1()
    {
        Color color = checkCondition1.GetComponent<Image>().color;
        color.r = 1f;
        color.g = 1f;
        color.b = 1f;

        checkCondition1.GetComponent<Image>().color = color;
        if (color1)
        {
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundBGM[13]);
            color1 = false;
        }
    }
    void NoneImage2()
    {
        Color color = checkCondition2.GetComponent<Image>().color;
        color.r = 1f;
        color.g = 1f;
        color.b = 1f;

        checkCondition2.GetComponent<Image>().color = color;
        if (color2)
        {
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundBGM[13]);
            color2 = false;
        }
    }
    void NoneImage3()
    {
        Color color = checkCondition3.GetComponent<Image>().color;
        color.r = 1f;
        color.g = 1f;
        color.b = 1f;

        checkCondition3.GetComponent<Image>().color = color;
        if (color3)
        {
            SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundBGM[13]);
            color3 = false;
        }
    }

    //void PencilSound()
    //{
    //    if(conditionCheck1 || conditionCheck2 || conditionCheck3)
    //    {
    //        SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundBGM[13]);
    //        conditionCheck1 = false;
    //        conditionCheck2 = false;
    //        conditionCheck3 = false;
    //    }
    //}
    bool loop1Mission = true;
    bool loop2Mission = true;

    public bool Interaction;
    void Condition()
    {
        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            if (bell.lobbyCondition1)
            {
                conditionCheck1 = true;
                ColorImage1();
            }

            if (BRD.lobbyCondition2)
            {
                conditionCheck2 = true;
                ColorImage2();
            }

            if (raycast.lobbyCondition3)
            {
                conditionCheck3 = true;
                ColorImage3();
            }
        }

        
        else if (SceneManager.GetActiveScene().name == "Loop1")
        {
            if (loop1Mission)
            {
                if (!MT1.triggerSwitch1)
                {
                    //conditionCheck1 = true;
                    ColorImage1();
                }

                if (raycast.hasEquip_Items[0] && raycast.hasCollect_Items[0])
                {
                    //conditionCheck2 = true;
                    ColorImage2();
                    if (CUM.isFunction1)
                    {
                        loop1_1QuestList.SetActive(false);
                        loop1Mission = false;
                    }
                }
            }
            else if (!loop1Mission)
            {
                loop1_2QuestList.SetActive(true);
                if(loop2Mission)
                {
                    NoneImage1();
                    NoneImage2();
                    loop2Mission = false;
                }
                if (raycast.iSwap1)
                {
                    ColorImage1();
                }
                
                // 작동 안됨.. 해결좀 ㅠ_ㅠ
                if (raycast.iSwap1 && Interaction)
                {
                    ColorImage2();
                }

            }
        }
    }
}
