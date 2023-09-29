using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flashlight_Switch : MonoBehaviour
{
    public GameObject lightGroup;
    
    bool lightSwitch = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
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
}
