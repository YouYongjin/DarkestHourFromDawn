using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flashlight_Switch : MonoBehaviour
{
    public GameObject lightGroup;
    
    bool lightSwitch = true;

    bool eIDown;

    void GetInput()
    {
        eIDown = Input.GetButtonDown("EquipInteraction");
    }

    public  void FlashLight()
    {
        if (eIDown)
        {
            if (lightSwitch)
            {
                lightGroup.gameObject.SetActive(false);
                lightSwitch = false;
            }
            else if (!lightSwitch)
            {
                lightGroup.gameObject.SetActive(true);
                lightSwitch = true;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        FlashLight();
        GetInput();
    }
}
