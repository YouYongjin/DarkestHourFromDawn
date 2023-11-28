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
    public Rigidbody dollRb;
    void Awake()
    {
        // �̱��� (���� ����): ��� ���� ������ �� �ִ�.
        instance = this;
    }

    public void SceneChange(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    // static�� �Է��� ���, Instance ��ΰ� �ƴ� �Լ��� ȣ���� �� �ִ�?
    //public static void SceneChange(string Scenename)Stop
    //{
    //    SceneManager.LoadScene(Scenename);
    //}

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

    public void Loop2TargetRotateEvent()
    {
        if (SceneManager.GetActiveScene().name == "Loop2")
        {
            if (raycast.hasCollect_Items[6])
                targetRotateMove.TargetRotateEvent(cameraT, targetT, 10f);
                dollRb.AddForce(new Vector3(0, 1, 0) * maxHeight);
        } 
    }
    // CItem[0] '�ϱ���' ���� �Լ�

    //public void CItemEvent1(int cItemIndex/*, GameObject isUIOn*/)
    //{
    //    //if (PCCamera.GetComponent<Raycast>().hasEquip_Items[0])
    //    //{
    //    //    Debug.Log("UI����");
    //    //}
    //    //hasCollect_Item = raycast.hasCollect_Items;

    //    if (raycast.hasCollect_Items[cItemIndex])
    //    {
    //        if (cItemIndex == 0)
    //        {
    //            CUM.isUIOn = true;
    //            //isUIOn.gameObject.SetActive(true);
    //            //Time.timeScale = 0;
    //            //PCCamera.GetComponent<FirstPersonCamera>().CameraMoveOn = false;
    //            if (Input.GetKeyDown("mouse 0"))
    //            {
    //                CUM.isUIOn = false;
    //                //Destroy(isUIOn);
    //                //Time.timeScale = 1;
    //                //PCCamera.GetComponent<FirstPersonCamera>().CameraMoveOn = true;
    //            }
    //        }


    //        //if (isUIOn)
    //        //{
    //        //    timer += Time.deltaTime;
    //        //    if (timer > waitingTime)
    //        //    {
    //        //        //isUIOn.gameObject.SetActive(false);
    //        //    }
    //        //}
    //    }
    //}

    //bool isUIOn = false;
    //public GameObject CEUI;
    //public void CE1Controller()
    //{
    //    if(isUIOn)
    //    {
    //        CEUI.gameObject.SetActive(true);
    //        Time.timeScale = 0;
    //        PCCamera.GetComponent<FirstPersonCamera>().CameraMoveOn = false;
    //    }
    //    else if(!isUIOn)
    //    {
    //        CEUI.gameObject.SetActive(false);
    //        Time.timeScale = 1;
    //        PCCamera.GetComponent<FirstPersonCamera>().CameraMoveOn = true;
    //    }

    //}

    void Update()
    {
        Intermit();
        GetInput();
        //CE1Controller();
        Loop2TargetRotateEvent();
    }
}
