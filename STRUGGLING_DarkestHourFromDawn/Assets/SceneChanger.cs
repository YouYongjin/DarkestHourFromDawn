using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    void OnCollisionEnter()
    {
        if (SceneManager.GetActiveScene().name == "Loop1")
        {
            //Debug.Log("�ش� ���� Loop1 �̸�, Loop2 ������Դϴ�.");
            SceneManager.LoadScene("Loop2");
        }
    }

    public void SceneList()
    {
        OnCollisionEnter();
    }

    private void Update()
    {
        SceneList();
    }
}
