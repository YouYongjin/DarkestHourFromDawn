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

    public void CItemEvent1(int itemIndex, GameObject isUIOn)
    {
        //if (PCCamera.GetComponent<Raycast>().hasEquip_Items[0])
        //{
        //    Debug.Log("UI생성");
        //}
        //hasCollect_Item = raycast.hasCollect_Items;
        if (raycast.hasCollect_Items[itemIndex])
        {
            if (itemIndex == 0)
            {
                isUIOn.gameObject.SetActive(true);
                Destroy(gameObject, 5);
            }
        }
    }

    void Update()
    {
        Intermit();
        GetInput();
    }
}
