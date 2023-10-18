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
        // �̱��� (���� ����): ��� ���� ������ �� �ִ�.
        instance = this;
    }

    public void SceneChange(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    // static�� �Է��� ���, Instance ��ΰ� �ƴ� �Լ��� ȣ���� �� �ִ�?
    //public static void SceneChange(string Scenename)
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
        //    Debug.Log("UI����");
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
