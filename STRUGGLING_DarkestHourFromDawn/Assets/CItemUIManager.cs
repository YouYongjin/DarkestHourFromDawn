using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CItemUIManager : MonoBehaviour
{
    public GameObject PCCamera;
    public GameObject cItemUI1;
    public GameObject cItemUI2;
    public GameObject cItemUI3;
    
    public Raycast raycast;
    public CameraShake cameraShake;
    public TargetRotateMove targetRotateMove;

    public bool isUIOn = false;
    public bool isFunction1 = false;
    public bool isFunction2 = false;
    public bool isFunction3 = false;

    public Transform cameraT;
    public Transform targetT;

    public Rigidbody dollRb;

    public float maxHeight = 10f;

    public void CItemEvent1()
    {
        if (SceneManager.GetActiveScene().name == "Loop1")
        { 
            if (raycast.hasCollect_Items[0] && !isFunction1)
            {
                isUIOn = true;
                CE1Controller();

                if (Input.GetKeyDown("mouse 0"))
                {
                    isFunction1= true;
                    isUIOn = false;
                    CE1Controller();
                }
            }
        }
    }

    public void CItemEvent2()
    {
        if (SceneManager.GetActiveScene().name == "Loop2")
        {
            if (raycast.hasCollect_Items[1] && !isFunction2)
            {
                isUIOn = true;
                CE2Controller();

                if (Input.GetKeyDown("mouse 0"))
                {
                    isFunction2 = true;
                    isUIOn = false;
                    CE2Controller();
                }
            }
        }
    }

    public void CItemEvent3()
    {
        if (SceneManager.GetActiveScene().name == "Loop2")
        {
            if (raycast.hasCollect_Items[6] && !isFunction3)
            {
                isUIOn = true;
                CE3Controller();

                if (Input.GetKeyDown("mouse 0"))
                {
                    isFunction3 = true;
                    isUIOn = false;
                    CE3Controller();
                }
            }
        }
    }

    public bool cameraShakeOn = false;
    void CE1Controller()
    {
        if (isUIOn)
        {
            cItemUI1.gameObject.SetActive(true);
            Time.timeScale = 0;
            PCCamera.GetComponent<FirstPersonCamera>().CameraMoveOn = false;
        }
        else if (!isUIOn)
        {
            cItemUI1.gameObject.SetActive(false);
            Time.timeScale = 1;
            PCCamera.GetComponent<FirstPersonCamera>().CameraMoveOn = true;
            cameraShakeOn = true;
            if (cameraShake.shakeDuration <= 0f)
            {
                cameraShakeOn = false;
            }
        }
    }
    void CE2Controller()
    {
        if (isUIOn)
        {
            cItemUI2.gameObject.SetActive(true);
            Time.timeScale = 0;
            PCCamera.GetComponent<FirstPersonCamera>().CameraMoveOn = false;
        }
        else if (!isUIOn)
        {
            cItemUI2.gameObject.SetActive(false);
            Time.timeScale = 1;
            PCCamera.GetComponent<FirstPersonCamera>().CameraMoveOn = true;
            cameraShakeOn = true;
            if (cameraShake.shakeDuration <= 0f)
            {
                cameraShakeOn = false;
            }
        }
    }

    public bool conditionOne = false;
    void CE3Controller()
    {
        if (isUIOn)
        {
            cItemUI3.gameObject.SetActive(true);
            Time.timeScale = 0;
            PCCamera.GetComponent<FirstPersonCamera>().CameraMoveOn = false;
        }
        else if (!isUIOn)
        {
            cItemUI3.gameObject.SetActive(false);
            Time.timeScale = 1;
            conditionOne = true;
            //PCCamera.GetComponent<FirstPersonCamera>().CameraMoveOn = true;
            //cameraShakeOn = true;
            //if (cameraShake.shakeDuration <= 0f)
            //{
            //    cameraShakeOn = false;
            //}

            // 넌 잠시 짜져있어
            //targetRotateMove.TargetRotateEvent(cameraT, targetT, 8f);
        }
    }
    bool conditionTwo = true;
    public void TargetRotate()
    {
        if(conditionTwo)
        StartCoroutine(TargetRotateCO());
    }

    IEnumerator TargetRotateCO()
    {
        yield return new WaitForSeconds(0.1f);
        targetRotateMove.TargetRotateEvent(cameraT, targetT, 8f);
        conditionTwo = false;
        dollRb.AddForce(new Vector3(7, 7f, 0) * maxHeight);
        yield return new WaitForSeconds(0.8f);
        PCCamera.GetComponent<FirstPersonCamera>().CameraMoveOn = true;
    }

    private void Update()
    {
        CItemEvent1();
        CItemEvent2();
        CItemEvent3();

        if(conditionOne)
        {
            TargetRotate();
        }
    }

}
