using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerV2 : MonoBehaviour
{
    Rigidbody rd;
    CharacterController controller;

    float moveSpeed = 1.2f;
    private bool isMoving;
    private float _moveSpeedClamp = 4f;

    //public GameObject Flashlight;

    bool cameraSwitch = true;


    GameObject nearObject;
    public GameObject aniCamera;

    void Start()
    {
        rd = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        isMoving = false;
    }
    void Update()
    {
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

        rd.velocity = moveDistance * moveSpeed;
        #endregion

        if (Input.GetKeyDown(KeyCode.S))
        {
            moveSpeed = moveSpeed - 0.5f;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            moveSpeed = 1.2f;
        }
        #region 개발자 단축키

        // 이동속도 대폭 증가
        if (Input.GetKeyDown(KeyCode.M))
        {
            moveSpeed = 5f;
        }
        #endregion
    }

    void OnCollisionStay(Collision collision)
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
}
