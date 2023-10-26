using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CItemUIManager : MonoBehaviour
{
    public GameObject PCCamera;
    public GameObject cItemUI1;
   
    public bool isUIOn = false;

    public void GetCItem0()
    {
        if(SceneManager.GetActiveScene().name == "Loop1")
        {
            GameManager.instance.CItemEvent1(0);
        }
    }
   
    public void CE1Controller()
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
        GetCItem0();
        CE1Controller();
    }
}
