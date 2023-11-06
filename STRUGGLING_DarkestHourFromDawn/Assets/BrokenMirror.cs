using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenMirror : MonoBehaviour
{
    public Raycast raycast;
    public GameObject mirrorPiece1;
    public GameObject mirrorPiece2;
    public GameObject mirrorPiece3;
    public GameObject mirrorPiece4;


    void MirrorPieceGroup()
    {

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
