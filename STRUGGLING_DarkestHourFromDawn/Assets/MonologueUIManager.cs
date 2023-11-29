using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueUIManager : MonoBehaviour
{
    public static MonologueUIManager instance;
    
    public GameObject backgroundImage;

    void Awake()
    {
        instance = this;
    }

    public MonologueUIList monologueDatabase;

    public void DoMonologue(GameObject Text)
    {

    }

}
