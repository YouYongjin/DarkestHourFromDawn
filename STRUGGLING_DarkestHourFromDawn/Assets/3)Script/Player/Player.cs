using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using static UnityEditor.Progress;

public class Player : MonoBehaviour
{
    Rigidbody rd;
    CharacterController controller;

    float moveSpeed = 1.2f;
    private bool isMoving;
    private float _moveSpeedClamp = 4f;

    //public GameObject Flashlight;

    bool iGet;
    bool iSwap1;
    bool iSwap2;
    bool iSwap3;

    GameObject nearObject;
    GameObject equipObject;
    int equipEItemIndex = -1;

    public GameObject[] eItems;
    public bool[] hasEItems;
    public bool[] hasCItems;

    public GameObject sceneChange;
    public GameObject puzzleTrigger;

    bool cameraSwitch = true;
    public GameObject aniCamera;

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
        EitemSwap();
        CitemAdd();

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

        // 카메라 애니메이션 Switch
        if (Input.GetKeyDown(KeyCode.R))
        {

            if (cameraSwitch)
            {
                aniCamera.gameObject.SetActive(false);
                cameraSwitch = false;
            }
            else if (!cameraSwitch)
            {
                aniCamera.gameObject.SetActive(true);
                cameraSwitch = true;
            }
        }
        #endregion
    }
    void GetInput()
    {
        iGet = Input.GetButtonDown("Interaction");

        iSwap1 = Input.GetButtonDown("Swap1");
        iSwap2 = Input.GetButtonDown("Swap2");
        iSwap3 = Input.GetButtonDown("Swap3");

    }

    void Interaction()
    {
        if (iGet && nearObject != null)
        {
            if (nearObject.tag == "EItem")
            {
                Item item = nearObject.GetComponent<Item>();
                int eItemIndex = item.value;
                hasEItems[eItemIndex] = true;

                Destroy(nearObject);
            }
            if (nearObject.tag == "CItem")
            {
                Item item = nearObject.GetComponent<Item>();
                int cItemIndex = item.value;
                hasCItems[cItemIndex] = true;

                nearObject.SetActive(false);
            }
        }
    }

    void EitemSwap()
    {
        if (iSwap1 && (!hasEItems[0] || equipEItemIndex == 0))
        {
            return;
        }
        if (iSwap2 && (!hasEItems[1] || equipEItemIndex == 1))
        {
            return;
        }
        if (iSwap3 && (!hasEItems[2] || equipEItemIndex == 2))
        {
            return;
        }

        int eItemIndex = -1;
        if (iSwap1) eItemIndex = 0;
        if (iSwap2) eItemIndex = 1;
        if (iSwap3) eItemIndex = 2;

        if (iSwap1 || iSwap2 || iSwap3)
        {
            if (equipObject != null)
                equipObject.SetActive(false);

            equipEItemIndex = eItemIndex;
            equipObject = eItems[eItemIndex];
            equipObject.SetActive(true);
        }
    }
    void CitemAdd()
    {
        int cItemIndex = -1;
        if (hasCItems[0] || cItemIndex == 0)
        {
            sceneChange.SetActive(true);
        }
        if (hasCItems[1] || cItemIndex == 1)
        {
            puzzleTrigger.SetActive(true);
        }
    }
    void OnTriggerStay(Collider other)
    {
        // 장착형 아이템 판단
        if (other.tag == "EItem")
        {
            nearObject = other.gameObject;
            Debug.Log(nearObject.name + "/" + nearObject.tag);
        }
        // 수집형 아이템 판단 
        if (other.tag == "CItem")
        {
            nearObject = other.gameObject;
            Debug.Log(nearObject.name + "/" + nearObject.tag);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "EItem")
        {
            nearObject = null;
        }

        if (other.tag == "CItem")
        {
            nearObject = null;
        }
    }
}
