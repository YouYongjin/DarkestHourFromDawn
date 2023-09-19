using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMoveController : MonoBehaviour
{    
    Rigidbody rd;
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 HorizontalMove = Vector3.zero;
        Vector3 VerticalMove = Vector3.zero;

        Vector3 moveDistance = Vector3.zero;

        HorizontalMove = transform.right * Input.GetAxis("Horizontal") * moveSpeed;
        VerticalMove = transform.forward * Input.GetAxis("Vertical") * moveSpeed;

        moveDistance = (HorizontalMove + VerticalMove ) ;

        rd.AddForce(moveDistance);
    }
}
