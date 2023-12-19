using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestUIManager : MonoBehaviour
{
    public CItemUIManager CUM;
    public GameLoading GL;

    public GameObject main;
    public GameObject lobbyQuestList;
    public GameObject loop1QuestList;
    public GameObject loop2QuestList;

    public Image checkCondition1;
    public Image checkCondition2;
    public Image checkCondition3;

    public bool Check1;

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

    }

    void Condition()
    {
        if (SceneManager.GetActiveScene().name == "Lobby")
        {
            //if ()

        }
    }

}
