using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Raycast raycast;
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
    //public static void SceneChange(string Scenename)
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
    bool isUIOn;
    public void CItemEvent1(int cItemIndex, GameObject isUIOn)
    {
        //if (PCCamera.GetComponent<Raycast>().hasEquip_Items[0])
        //{
        //    Debug.Log("UI생성");
        //}
        //hasCollect_Item = raycast.hasCollect_Items;

        if (raycast.hasCollect_Items[cItemIndex])
        {
            if (cItemIndex == 0)
            {
                isUIOn.gameObject.SetActive(true);
            }

            if(isUIOn)
            {
                timer += Time.deltaTime;
                if(timer > waitingTime)
                {
                    isUIOn.gameObject.SetActive(false);
                }
            }
        }
    }

    // CItem[1] '신문기사', EItem[0] '손전등' 관련 함수
    public void CItemEvent2(int eItemIndex,int cItemIndex, GameObject lightObj)
    {
        if(raycast.hasCollect_Items[cItemIndex] && raycast.hasEquip_Items[eItemIndex])
        {
            if (cItemIndex == 1 && eItemIndex == 0)
            {
                lightObj.gameObject.SetActive(false);
            }
        }
    }

    public void TestEvent(bool[] hasE, bool[] hasC, int eItemIndex, int cItemIndex, GameObject light)
    {
        hasE = raycast.hasEquip_Items;
        hasC = raycast.hasCollect_Items;
        {
            if(hasE[eItemIndex] && hasC[cItemIndex])
            {
                Debug.Log("완료1");
                if (cItemIndex == 1 && eItemIndex == 0)
                {
                    light.gameObject.SetActive(false);
                    Debug.Log("완료2");
                }
            }
        }
    }

    void Update()
    {
        Intermit();
        GetInput();
    }
}
