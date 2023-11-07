using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterSwitch : MonoBehaviour
{
    public GameObject lightGroup;

    public bool lightSwitch = true;

    public bool eIDown;

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
            }
            else if (!lightSwitch)
            {
                LightOn();

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