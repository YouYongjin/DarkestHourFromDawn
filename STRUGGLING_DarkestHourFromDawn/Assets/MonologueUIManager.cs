using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueUIManager : MonoBehaviour
{
    public static MonologueUIManager instance;
    public MonologueUIList monologueDatabase;
    
    public GameObject backgroundImage;

    public bool UIOn = false;

    void Awake()
    {
        instance = this;
    }

    public void CallMonologue(float start, float end, GameObject text)
    {
        StartCoroutine(MonologueEventCO(start, end, text));
    }

    IEnumerator MonologueEventCO(float start, float end, GameObject text)
    {
        yield return new WaitForSeconds(start);
        UIOn = true;
        backgroundImage.SetActive(UIOn);
        text.SetActive(UIOn);
        yield return new WaitForSeconds(end);
        UIOn = false;
        backgroundImage.SetActive(UIOn);
        text.SetActive(UIOn);
    }
}
