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
    //public CameraShake cameraShake;


    public bool eDown;
    bool intermitOn = true;
    public GameObject intermitUI;
    public GameObject PCCamera;
    //PlayerV2 player;

    void Awake()
    {
        // 싱글톤 (현재 형태): 모든 곳을 개입할 수 있다.
        instance = this;
    }

    public void SceneChange(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    // static을 입력할 경우, Instance 경로가 아닌 함수를 호출할 수 있다?
    //public static void SceneChange(string Scenename)Stop
    //{
    //    SceneManager.LoadScene(Scenename);
    //}

    public void CItem(Player player, int ItemIndex, string SceneName)
    {
        // SceneName = (SceneName)을 String 배열에 입력하고 싶음.
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
    // CItem[0] '일기장' 관련 함수

    //public void CItemEvent1(int cItemIndex/*, GameObject isUIOn*/)
    //{
    //    //if (PCCamera.GetComponent<Raycast>().hasEquip_Items[0])
    //    //{
    //    //    Debug.Log("UI생성");
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
    }
}
