using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueUIManager : MonoBehaviour
{
    public static MonologueUIManager instance;
    
    public GameObject backgroundImage;

    public bool UIOn = false;

    void Awake()
    {
        instance = this;
    }

    public void MonologueUIOn()
    {
        StartCoroutine(MonologueEventCO());
    }

    IEnumerator MonologueEventCO()
    {
        yield return new WaitForSeconds(0);
        backgroundImage.SetActive(true);
        UIOn = true;
        yield return new WaitForSeconds(3);
        backgroundImage.SetActive(false);
        UIOn = false;
    }

    public MonologueUIList monologueDatabase;

    public void DoMonologue(GameObject textNum)
    {
        MonologueUIOn();
        if(UIOn)
        {
            textNum.SetActive(true);
        }
    }

    // �Ű������� �μ� ���� ����
    //private void Update()
    //{
    //    DoMonologue();
    //}
}
