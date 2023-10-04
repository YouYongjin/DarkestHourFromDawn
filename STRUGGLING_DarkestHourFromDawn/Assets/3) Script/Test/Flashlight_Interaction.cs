using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight_Interaction : MonoBehaviour
{
    public GameObject field_Flashlight;
    public GameObject UI_Flashlight;
    bool UI_FlashlightON;

    public GameObject player_Flashlight;
    public GameObject Light;
    bool lightSwitch = true;

    public bool isOn;
    bool isHasFlashlight = false;

    void Start()
    {
        isOn = true;
        UI_FlashlightON = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Interaction"))
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Flashlight"))
            {
                isHasFlashlight = true;
                field_Flashlight.gameObject.SetActive(false);
                UI_Flashlight.gameObject.SetActive(true);
                UI_FlashlightON = true;
                if (UI_FlashlightON == true)
                {
                    Destroy(UI_Flashlight.gameObject, 3);
                }

                player_Flashlight.gameObject.SetActive(true);
            }
        }    
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && isHasFlashlight)
        {
            if (isOn)
            {
                player_Flashlight.gameObject.SetActive(false);
                isOn = false;
            }
            else if (!isOn)
            {
                player_Flashlight.gameObject.SetActive(true);
                isOn = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && isOn)
        {
            if (lightSwitch)
            {
                Light.gameObject.SetActive(false);
                lightSwitch = false;
            }
            else if (!lightSwitch)
            {
                Light.gameObject.SetActive(true);
                lightSwitch = true;
            }
        }

    }

}
