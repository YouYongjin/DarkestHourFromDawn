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
    // CItem[0] '�ϱ���' ���� �Լ�
    bool isUIOn;
    public void CItemEvent1(int cItemIndex, GameObject isUIOn)
    {
        //if (PCCamera.GetComponent<Raycast>().hasEquip_Items[0])
        //{
        //    Debug.Log("UI����");
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

    // CItem[1] '�Ź����', EItem[0] '������' ���� �Լ�
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
                Debug.Log("�Ϸ�1");
                if (cItemIndex == 1 && eItemIndex == 0)
                {
                    light.gameObject.SetActive(false);
                    Debug.Log("�Ϸ�2");
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
