using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEventManager : MonoBehaviour
{
    public Raycast raycast;
    public OneShotSurpriseDoor ASSDoor;
    public DoorLock LDoor;
    public QuestUIManager QUM;

    public bool oneShotSurprise = false;
    public GameObject lightOn;

    public void Loop2Root()
    {
        // �� üũ
        if (SceneManager.GetActiveScene().name == "Loop1")
        {
            Debug.Log("ù ��° ��");
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
        else if (SceneManager.GetActiveScene().name == "Loop2")
        {
            raycast.hasEquip_Items[0] = true;
            if (raycast.hasCollect_Items[6])
            {
                LDoor.isLocked = false;
            }
            else
            {
                LDoor.isLocked = true;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Lobby")
        {
            if (QUM.conditionCheck1 && QUM.conditionCheck2 && QUM.conditionCheck3)
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
