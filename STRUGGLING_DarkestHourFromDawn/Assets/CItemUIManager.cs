using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CItemUIManager : MonoBehaviour
{
    public GameObject cItemUI;

    public void GetCItem0()
    {
        if(SceneManager.GetActiveScene().name == "Loop1")
        {
            GameManager.instance.CItemEvent1(0, cItemUI);
        }
    }

    private void Update()
    {
        GetCItem0();
    }
}
