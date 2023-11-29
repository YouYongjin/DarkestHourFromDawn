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
    }
}
