using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OneShotSurpriseDoor : Door
{
    public Raycast raycast;
    public Animator animOpen;
    public SceneEventManager SEM;
    //bool OneShotSurprise = false; 
    private void Start()
    {
        animOpen.Play("OpenDoor");
        isOpen = true;
        //if(SEM.OneShotSurprise)
        //{
        //    animOpen.Play("DoorV2");
        //}
    }

    public void SurpriseAnim()
    {
        animOpen.Play("SurpriseDoor");
        //OneShotSurprise = true;
        //return;
        //if (OneShotSurprise)
        //{
        //    animOpen.Play("DoorV2");
        //}
    }
    public void DefaultAnim()
    {
        animOpen.Play("DoorV2");
    }

    public static void OpenAnim()
    {
        //animOpen.Play("OpenDoor");
        
    }


    public override bool CheckOpen()
    {
        return true;

    }
}
