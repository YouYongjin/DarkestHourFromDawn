using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class LighterSwitch : MonoBehaviour
{
    public GameObject lightGroup;
    public Animator anim;
    public bool lightSwitch;

    public bool eIDown;

    void Awake()
    {
        lightSwitch = false;
    }

    void GetInput()
    {
        eIDown = Input.GetButtonDown("EquipInteraction");
    }

    public void Lighter()
    {
        if (eIDown)
        {
            if (lightSwitch)
            {
                LightOff();
                anim.Play("LighterOff");
                Debug.Log(lightSwitch);
            }
            else if (!lightSwitch)
            {
                LightOn();
                anim.Play("LighterOn");
                Debug.Log(lightSwitch);
            }
        }
    }

    public void LightOff()
    {
        lightGroup.gameObject.SetActive(false);
        lightSwitch = false;
    }

    public void LightOn()
    {
        lightGroup.gameObject.SetActive(true);
        lightSwitch = true;
    }


    // Update is called once per frame
    void Update()
    {
        Lighter();
        GetInput();
    }
}
