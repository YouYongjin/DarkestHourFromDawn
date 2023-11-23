using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flashlight_Switch : MonoBehaviour
{
    public GameObject lightGroup;
    public AudioSource audioSource;

    public bool lightSwitch = true;

    public bool eIDown;

    void GetInput()
    {
        eIDown = Input.GetButtonDown("EquipInteraction");
    }

    public void FlashLight()
    {
        if (eIDown)
        {
            if (lightSwitch)
            {
                LightOff();
                SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundCharacter[2]);
            }
            else if (!lightSwitch)
            {
                LightOn();
                SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundCharacter[2]);
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
        FlashLight();
        GetInput();
    }
}
