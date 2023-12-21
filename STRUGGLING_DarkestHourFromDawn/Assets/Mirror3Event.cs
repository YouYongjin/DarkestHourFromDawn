using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mirror3Event : MonoBehaviour
{
    public Mirror3trigger M3t;
    public Rigidbody MirrorPiece3;

    public float maxHeight = 10f;

    bool end;

    private void Start()
    {
        end = true;
    }

    void MirrorThrow()
    {
        if(M3t.EventOn)
        {
            if(end)
            {
                Debug.Log("AddForce ½ÇÇà!#$@@$%(&^(%$^!@%!@%!#@%!#$%@¤Â^&%");
                MirrorPiece3.AddForce(new Vector3(8, 7.5f, 0) * maxHeight);
                end = false;
            }
        }
    }

    private void Update()
    {
        MirrorThrow();
    }
}
