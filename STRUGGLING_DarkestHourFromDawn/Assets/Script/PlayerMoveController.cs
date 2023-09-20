using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMoveController : MonoBehaviour
{    
    Rigidbody rd;
    public float moveSpeed = 1f;
    private bool isMoving;

    public GameObject Flashlight;
    //public GameObject[] weapons;
    //public bool[] hasWeapons;

    bool iDown;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        isMoving = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        //바닥에 닿으면
        if (collision.gameObject.CompareTag("Ground"))
        {
            //이동이 가능한 상태로 변경
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

    }

    void GetInput()
    {
        iDown = Input.GetButtonDown("Interaction");
    }
    void Update()
    {
        //interaction();
        if (isMoving)
        {
            Vector3 HorizontalMove = Vector3.zero;
            Vector3 VerticalMove = Vector3.zero;

            Vector3 moveDistance = Vector3.zero;

            HorizontalMove = transform.right * Input.GetAxis("Horizontal") * moveSpeed;
            VerticalMove = transform.forward * Input.GetAxis("Vertical") * moveSpeed;

            moveDistance = (HorizontalMove + VerticalMove);

            rd.AddForce(moveDistance);
        }
    }    //void interaction()
    //{
    //    if (iDown && Flashlight != null)
    //    {
    //        if(this.gameObject.layer == LayerMask.NameToLayer("Flashlight"))
    //        {
                
    //        }
    //    }
    //}

}
