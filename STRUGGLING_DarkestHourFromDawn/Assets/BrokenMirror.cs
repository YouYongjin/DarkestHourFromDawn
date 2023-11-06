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

    int haveCount;
    int needCount;

    private void Start()
    {
        haveCount = 0;
        needCount = 4;
    }

    private void Update()
    {
        MirrorPieceGroup();
        //MirrorCount();
    }

    void MirrorPieceGroup()
    {
        MirrorPiece1();
        MirrorPiece2();
        MirrorPiece3();
        MirrorPiece4(); 
    }

    void MirrorCount()
    {
        if (raycast.hasCollect_Items[2])
        {
            mirrorCount.text = haveCount + 1 + " / 4";
            haveCount = haveCount + 1;
            //return;
        }
        if (raycast.hasCollect_Items[3])
        {
            mirrorCount.text = haveCount + 1 + " / 4";
            haveCount = haveCount + 1;
            //return;
        }
        if (raycast.hasCollect_Items[4])
        {
            mirrorCount.text = haveCount + 1 + " / 4";
            haveCount = haveCount + 1;
            //return;
        }
        if (raycast.hasCollect_Items[5])
        {
            mirrorCount.text = haveCount + 1 + " / 4";
            haveCount = haveCount + 1;
            //return;
        }
    }

    void MirrorPiece1()
    {
        if (raycast.hasCollect_Items[2])
        {
            mirrorPiece1.SetActive(true);
        }
    }
    void MirrorPiece2()
    {
        if (raycast.hasCollect_Items[3])
        {
            mirrorPiece2.SetActive(true);
        }
    }
    void MirrorPiece3()
    {
        if (raycast.hasCollect_Items[4])
        {
            mirrorPiece3.SetActive(true);
        }
    }
    void MirrorPiece4()
    {
        if (raycast.hasCollect_Items[5])
        {
            mirrorPiece4.SetActive(true);
        }
    }
}
