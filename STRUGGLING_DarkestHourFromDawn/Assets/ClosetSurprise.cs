using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetSurprise : MonoBehaviour
{
    public Closet closet;

    public Animator animDoll;
    public Animator animCloset;

    public GameObject surpriseDoll;

    public float destroyTimer;

    bool oneShot = true;

    private void Start()
    {
        animCloset.Play("ClosetLittleOn");
        destroyTimer = 0.3f;
    }

    public void DollDestroy()
    {
        StartCoroutine(DollDestroyEventCO());
    }

    IEnumerator DollDestroyEventCO()
    {
        yield return new WaitForSeconds(destroyTimer);
        Destroy(surpriseDoll);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && oneShot)
        {
            animDoll.Play("SurpriseDoll");
            animCloset.Play("ClosetLittleOff");
            oneShot = false;
            DollDestroy();
            closet.isOpen = false;
        }
    }
}
