using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Player: MonoBehaviour
{
    Rigidbody rd;
    CharacterController controller;

    public float moveSpeed = 1f;
    private bool isMoving;
    private float _moveSpeedClamp = 4f;

    //public GameObject Flashlight;

    bool iGet;

    GameObject nearObject;

    public GameObject[] eItems;
    public bool[] hasEItems;

    void Start()
    {
        rd = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        isMoving = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {

            isMoving = true;
        }
        else if (collision.gameObject.CompareTag("StopZone"))
        {
            isMoving = false;
        }
    }

    void Update()
    {
        GetInput();
        Interaction();

        if (!isMoving) return;

        #region 송교수님 이동 코드
        Vector3 HorizontalMove = Vector3.zero;
        Vector3 VerticalMove = Vector3.zero;

        Vector3 moveDistance = Vector3.zero;

        HorizontalMove = transform.right * Input.GetAxis("Horizontal");
        VerticalMove = transform.forward * Input.GetAxis("Vertical");
        #endregion

        # region 이상신, 최강산 코드
        moveDistance = (HorizontalMove + VerticalMove).normalized;

        //rd.AddForce(moveDistance * moveSpeed);
        // rd.velocity = new Vector3(Mathf.Clamp(rd.velocity.x, -_moveSpeedClamp, _moveSpeedClamp), rd.velocity.y, Mathf.Clamp(rd.velocity.z, -_moveSpeedClamp, _moveSpeedClamp));
        rd.velocity = moveDistance * moveSpeed;
        #endregion
    }

    void GetInput()
    {
        iGet = Input.GetButtonDown("Interaction");
    }

    void Interaction()
    {
        if(iGet && nearObject != null) 
        {
            if(nearObject.tag == "EItem")
            {
                Item item = nearObject.GetComponent<Item>();
                int eItemIndex = item.value;
                hasEItems[eItemIndex] = true;

                Destroy(nearObject);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "EItem")
            nearObject = other.gameObject;

            Debug.Log(nearObject.name);
       
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "EItem")
            nearObject = null;
        
    }
}
