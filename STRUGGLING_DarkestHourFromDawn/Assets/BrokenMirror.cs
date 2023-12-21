using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrokenMirror : MonoBehaviour
{
    public Raycast raycast;
    public GameObject mirrorPiece1;
    public GameObject mirrorPiece2;
    public GameObject mirrorPiece3;
    public GameObject mirrorPiece4;
    public TMP_Text mirrorCount;

    public AudioSource audioSource;

    public bool piece1Check = false;
    public bool piece2Check = false;
    public bool piece3Check = false;
    public bool piece4Check = false;

    private void Update()
    {
        MirrorPieceGroup();
    }

    void MirrorPieceGroup()
    {
        MirrorPiece1();
        MirrorPiece2();
        MirrorPiece3();
        MirrorPiece4(); 
    }

    public void MirrorCount()
    {
        int hasItem = 0;
        for (int i = 1; i < 6; i++)
        {
            if (raycast.hasCollect_Items[i])
                hasItem++;
            if (hasItem == 5)
                //SoundManager.instance.PlayAudioSource(audioSource, SoundManager.instance.dataBase.soundEffect[6]);
            return;
        }
        mirrorCount.text = $"{hasItem} / 4";
        

    }
     void MirrorPiece1()
    {
        if (raycast.hasCollect_Items[2])
        {
            mirrorPiece1.SetActive(true);
            piece1Check = true;
        }
    }
    void MirrorPiece2()
    {
        if (raycast.hasCollect_Items[3])
        {
            mirrorPiece2.SetActive(true);
            piece2Check = true;
        }
    }
    void MirrorPiece3()
    {
        if (raycast.hasCollect_Items[4])
        {
            mirrorPiece3.SetActive(true);
            piece3Check = true;
        }
    }
    void MirrorPiece4()
    {
        if (raycast.hasCollect_Items[5])
        {
            mirrorPiece4.SetActive(true);
            piece4Check = true;
        }
    }
}
