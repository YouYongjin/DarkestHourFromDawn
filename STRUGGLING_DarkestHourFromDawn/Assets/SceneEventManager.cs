using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEventManager : MonoBehaviour
{
    public Raycast raycast;
    public OneShotSurpriseDoor ASSDoor;
    public DoorLock LDoor;

    public bool oneShotSurprise = false;
    public GameObject lightOn;

    //public GameObject doorEvent1;


    public void Loop2Root()
    {
        // ¾À Ã¼Å©
        if (SceneManager.GetActiveScene().name == "Loop1")
        {
            Debug.Log("Ã¹ ¹øÂ° ¾À");
            if (raycast.hasEquip_Items[0] && raycast.hasCollect_Items[0])
            {
                if (!oneShotSurprise)
                {
                    ASSDoor.SurpriseAnim();
                    LDoor.isLocked = false;
                    oneShotSurprise = true;
                    lightOn.gameObject.SetActive(false);
                }
                else if (oneShotSurprise)
                {
                    //ASSDoor.DefaultAnim();
                    ASSDoor.animOpen.SetBool("isOpen", true);
                    ASSDoor.CheckOpen();
                }
            }
            else
            {
                LDoor.isLocked = true;
            }
        }
        if(SceneManager.GetActiveScene().name == "Loop2")
        {
            raycast.hasEquip_Items[0] = true;
            if (raycast.hasEquip_Items[6])
            {
                LDoor.isLocked = false;
            }
            else
            {
                LDoor.isLocked = true;
            }
        }

    }

    private void Update()
    {
        Loop2Root();
    }
}
