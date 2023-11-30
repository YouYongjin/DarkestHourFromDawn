using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public Raycast raycast;
    public FirstPersonCamera FPC;
    public CItemUIManager CUM;
    public TargetRotateMove targetRotateMove;
    public Surprise_Doll surpriseDoll;
    //public CameraShake cameraShake;


    public bool eDown;
    bool intermitOn = true;
    public GameObject intermitUI;
    public GameObject PCCamera;
    //PlayerV2 player;

    public Transform cameraT;
    public Transform targetT;

    //public Vector3 dollVector;
    public float maxHeight = 10f;
    //public Rigidbody dollRb;
    void Awake()
    {
        // �̱��� (���� ����): ��� ���� ������ �� �ִ�.
        instance = this;
    }

    public void SceneChange(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void CItem(Player player, int ItemIndex, string SceneName)
    {
        // SceneName = (SceneName)�� String �迭�� �Է��ϰ� ����.
        if (player.hasCItems[ItemIndex])
        {
            SceneManager.LoadScene(SceneName);
        }
    }
    float timer;
    int waitingTime;

    void Start()
    {
        timer = 0.0f;
        waitingTime = 5;
        
    }

    public void GetInput()
    {
        eDown = Input.GetButtonDown("Intermit");
    }


    
    public void Intermit()
    {
        if(eDown && intermitOn)
        {
            intermitUI.SetActive(true);
            Time.timeScale = 0;
            intermitOn = false;
            PCCamera.GetComponent<FirstPersonCamera>().CameraMoveOn = false;
        }
        else if (eDown && !intermitOn)
        {
            intermitUI.SetActive(false);
            Time.timeScale = 1;
            intermitOn = true;
            PCCamera.GetComponent<FirstPersonCamera>().CameraMoveOn = true;
        }
    }

    void Update()
    {
        Intermit();
        GetInput();
        // DoMonogueUIOn() 에서 업데이트 필요.
        //MonologueLoop1();
        MonologueLoop1();
        //monologueSwitch = false;
        //MonologueCheck();
    }

    
    //void MonologueCheck()
    //{
    //    monologueSwitch = true;
    //    if (monologueSwitch)
    //    {
    //        MonologueLoop1();
    //    }
    //}

    bool monologueSwitch1 = true;
    bool monologueSwitch2 = true;


    public void MonologueLoop1()
    {
        if (SceneManager.GetActiveScene().name == "Loop1")
        {
            // 첫 번째 독백
            if (monologueSwitch1)
            {
                MonologueUIManager.instance.CallMonologue(1f, 4.5f,MonologueUIManager.instance.monologueDatabase.monologueUI[0]);
                monologueSwitch1 = false;
            }
            // 두번째 독백
            if (!surpriseDoll.isSurrprise)
            {
                if (monologueSwitch2)
                { 
                    MonologueUIManager.instance.CallMonologue(1f, 4.5f, MonologueUIManager.instance.monologueDatabase.monologueUI[1]);
                    monologueSwitch2 = false;
                }
            }
        }
    }

    public void MonologueLoop2()
    {

    }
}
