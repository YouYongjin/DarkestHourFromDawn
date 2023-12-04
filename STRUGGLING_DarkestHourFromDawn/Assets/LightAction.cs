using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAction : MonoBehaviour
{
    float random;
    bool lightSwitch;
    private float timer;
    float realTimer;
    private Light light;

    void Start()
    {
        random = Random.Range(0.1f, 0.3f);
        light = GetComponent<Light>();
    }
    void Update()
    {
        realTimer += Time.deltaTime;
        if (realTimer < 2)
        {
            SwitchLight(lightSwitch);
            timer += Time.deltaTime;
            if (timer > random)
            {
                timer = 0;
                lightSwitch = !lightSwitch;
                random = Random.Range(0.1f, 0.3f);
            }
        }
        else
        {
            SwitchLight(true);
        }
        
    }

    void SwitchLight(bool Switch)
    {
        if(Switch)
        {
            light.intensity = 0.2f;
        }
        else
        {
            light.intensity = 0;
        }
    }
}
