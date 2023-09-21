using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    Rigidbody rd;
    CharacterController controller;
    public float moveSpeed = 1f;
    private bool isMoving;
    private float _moveSpeedClamp = 4f;

    public GameObject Flashlight;
    //public GameObject[] weapons;
    //public bool[] hasWeapons;

    bool iDown;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        isMoving = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        //�ٴڿ� ������
        if (collision.gameObject.CompareTag("Ground"))
        {
            //�̵��� ������ ���·� ����
            isMoving = true;
        }
        else if (collision.gameObject.CompareTag("StopZone"))
        {
            isMoving = false;
        }

    }

    //void GetInput()
    //{
    //    iDown = Input.GetButtonDown("Interaction");
    //}
    void Update()
    {
        //interaction();

        if (!isMoving) return;

        #region �۱����� �̵� �ڵ�
        Vector3 HorizontalMove = Vector3.zero;
        Vector3 VerticalMove = Vector3.zero;

        Vector3 moveDistance = Vector3.zero;

        HorizontalMove = transform.right * Input.GetAxis("Horizontal");
        VerticalMove = transform.forward * Input.GetAxis("Vertical");

        //�̻��, �ְ��� �ڵ�
        moveDistance = (HorizontalMove + VerticalMove).normalized;

        //rd.AddForce(moveDistance * moveSpeed);
        // rd.velocity = new Vector3(Mathf.Clamp(rd.velocity.x, -_moveSpeedClamp, _moveSpeedClamp), rd.velocity.y, Mathf.Clamp(rd.velocity.z, -_moveSpeedClamp, _moveSpeedClamp));
        rd.velocity = moveDistance * moveSpeed;
        #endregion
    }

    //void interaction()
    //{
    //    if (iDown && Flashlight != null)
    //    {
    //        if(this.gameObject.layer == LayerMask.NameToLayer("Flashlight"))
    //        {

    //        }
    //    }
    //}

}
