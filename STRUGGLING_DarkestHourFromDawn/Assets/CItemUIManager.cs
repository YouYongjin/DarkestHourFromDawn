using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CItemUIManager : MonoBehaviour
{
    public GameObject PCCamera;
    public GameObject cItemUI1;
    public Raycast raycast;
   
    public bool isUIOn = false;
    public bool isFunction = false;
    public void CItemEvent1()
    {
        if (SceneManager.GetActiveScene().name == "Loop1")
        { 
            if (raycast.hasCollect_Items[0] && !isFunction)
            {
                isUIOn = true;
                CE1Controller();

                if (Input.GetKeyDown("mouse 0"))
                {
                    isFunction = true;
                    isUIOn = false;
                    CE1Controller();
                }
            }
        }
    }


    //public void GetCItem0()
    //{
    //    if (SceneManager.GetActiveScene().name == "Loop1")
    //    {
    //        GameManager.instance.CItemEvent1(0);
    //    }
    //}
   
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
        }

    }

    private void Update()
    {
        //GetCItem0();
        CItemEvent1();
    }

}
