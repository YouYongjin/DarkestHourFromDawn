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
    public SurpriseEvent surpriseEvent;
    public BrokenMirror brokenMirror;
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

    bool monologueSwitch1 = true;
    bool monologueSwitch2 = true;
    bool monologueSwitch3 = true;
    bool monologueSwitch4 = true;
    bool monologueSwitch5 = true;
    bool monologueSwitch6 = true;
    bool monologueSwitch7 = true;
    bool monologueSwitch8 = true;
    bool monologueSwitch9 = true;
    bool monologueSwitch10 = true;


    public void MonologueLoop1()
    {
        if (SceneManager.GetActiveScene().name == "Loop1")
        {
            // 첫 번째 독백
            if (monologueSwitch1)
            {
                MonologueUIManager.instance.CallMonologue(0.5f, 3f,MonologueUIManager.instance.monologueDatabase.monologueUI[0]);
                monologueSwitch1 = false;
            }

            // 두 번째 독백
            if (!surpriseDoll.isSurrprise)
            {
                if (monologueSwitch2)
                { 
                    MonologueUIManager.instance.CallMonologue(1f, 4.5f, MonologueUIManager.instance.monologueDatabase.monologueUI[1]);
                    monologueSwitch2 = false;
                }
            }

            // 네 번째 독백
            if (CUM.cameraShakeOn)
            {
                if (monologueSwitch3)
                {
                    MonologueUIManager.instance.CallMonologue(0.5f, 4f, MonologueUIManager.instance.monologueDatabase.monologueUI[2]);
                    monologueSwitch3 = false;
                }
            }
        }
    }

    public void MonologueLoop2()
    {
        if (SceneManager.GetActiveScene().name == "Loop2")
        {
            // 여섯 번째 독백
            if (monologueSwitch4)
            {
                MonologueUIManager.instance.CallMonologue(0.5f, 2f, MonologueUIManager.instance.monologueDatabase.monologueUI[3]);
                monologueSwitch4 = false;
            }

            // 일곱 번째 독백
            if (monologueSwitch5)
            {
                MonologueUIManager.instance.CallMonologue(2.55f, 2.25f, MonologueUIManager.instance.monologueDatabase.monologueUI[4]);
                monologueSwitch5 = false;
            }

            // 여덟 번째 독백
            if (!surpriseDoll.isSurrprise)
            {
                if (monologueSwitch6)
                {
                    MonologueUIManager.instance.CallMonologue(0f, 2.5f, MonologueUIManager.instance.monologueDatabase.monologueUI[5]);
                    monologueSwitch6 = false;
                }
            }    

            // 아홉 번째 독백
            if(surpriseEvent.lookAtBear)
            {
                if (monologueSwitch7)
                {
                    MonologueUIManager.instance.CallMonologue(0.6f, 2.5f, MonologueUIManager.instance.monologueDatabase.monologueUI[6]);
                    monologueSwitch7 = false;
                }
            }

            // 열 번째 독백
            if (brokenMirror.piece1Check || brokenMirror.piece2Check || brokenMirror.piece3Check || brokenMirror.piece4Check)
            {
                if (monologueSwitch8)
                {
                    MonologueUIManager.instance.CallMonologue(0f, 2.5f, MonologueUIManager.instance.monologueDatabase.monologueUI[7]);
                    monologueSwitch8 = false;
                }

                if (monologueSwitch9)
                {
                    MonologueUIManager.instance.CallMonologue(3.05f, 2.85f, MonologueUIManager.instance.monologueDatabase.monologueUI[8]);
                    monologueSwitch9 = false;
                }
            }

            // 열한 번째 독백
            if (CUM.cameraShakeOn)
            {
                if (monologueSwitch10)
                {
                    MonologueUIManager.instance.CallMonologue(0f, 2.5f, MonologueUIManager.instance.monologueDatabase.monologueUI[9]);
                    monologueSwitch10 = false;
                }

            }
        }
    }
    void Update()
    {
        Intermit();
        GetInput();
        MonologueLoop1();
        MonologueLoop2();
    }
}
