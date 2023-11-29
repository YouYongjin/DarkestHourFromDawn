using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveSurprise_Door : MonoBehaviour
{
    public Raycast raycast;
    public SceneEventManager sem;
    public Animator anim;

    public bool isSDoorOn;
    
    private void Start()
    {
        isSDoorOn = false;
    }

    private void Update()
    {
        //SceneLoop2();
    }
}
