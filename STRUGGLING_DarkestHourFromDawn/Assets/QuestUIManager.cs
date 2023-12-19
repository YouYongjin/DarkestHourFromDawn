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

    public GameObject main;
    public GameObject lobbyQuestList;
    public GameObject loop1QuestList;
    public GameObject loop2QuestList;

    public GameObject checkCondition1;
    public GameObject checkCondition2;
    public GameObject checkCondition3;

    public bool conditionCheck1;
    public bool conditionCheck2;
    public bool conditionCheck3;

    void Awake()
    {

    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            lobbyQuestList.SetActive(true);
        }

        else if (SceneManager.GetActiveScene().name == "Loop1")
        {
            loop1QuestList.SetActive(true);

        }

        else if (SceneManager.GetActiveScene().name == "Loop2")
        {
            loop2QuestList.SetActive(true);
        }

    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Lobby")
        {
            if (CUM.isFunction4)
            {
                main.SetActive(true);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Loop1")
        {
            main.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Loop2")
        {
            main.SetActive(true);
        }
        Condition();
    }

    void ColorImage1()
    {
        Color color = checkCondition1.GetComponent<Image>().color;
        color.r = 1f;
        color.g = 1f;
        color.b = 0f;

        checkCondition1.GetComponent<Image>().color = color;
    }
    void ColorImage2()
    {
        Color color = checkCondition2.GetComponent<Image>().color;
        color.r = 1f;
        color.g = 1f;
        color.b = 0f;

        checkCondition2.GetComponent<Image>().color = color;
    }
    void ColorImage3()
    {
        Color color = checkCondition3.GetComponent<Image>().color;
        color.r = 1f;
        color.g = 1f;
        color.b = 0f;

        checkCondition3.GetComponent<Image>().color = color;
    }

    void Condition()
    {
        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            if (bell.lobbyCondition1)
            {
                ColorImage1();
                conditionCheck1 = true;
            }

            if (BRD.lobbyCondition2)
            {
                ColorImage2();
                conditionCheck2 = true;
            }

            if (raycast.lobbyCondition3)
            {
                ColorImage3();
                conditionCheck3 = true;
            }
        }
    }

}
