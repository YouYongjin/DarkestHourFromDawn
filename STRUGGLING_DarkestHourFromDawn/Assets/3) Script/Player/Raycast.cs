using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    //public OpenDoorV2 DoorOn;
    //public NoneDoorV2 DoorOff;
    RaycastHit hit;
    public BrokenMirror brokenMirror;
    public SurpriseEvent surpriseEvent;

    public GameObject gameManager;
    public LayerMask layerMask;
    public LighterSwitch lighterSwitch;

    public GameObject Aim;
    GameObject nearObject;
    GameObject nowEquipItem;
    public GameObject cItemUI;
    public GameObject fireShader;

    // 표시할 아이템 변수
    public GameObject[] equip_Items;
    public GameObject[] collect_Items;

    // 아이템 획득 변수
    public bool[] hasEquip_Items;
    public bool[] hasCollect_Items;

    public bool iDown;
    public bool iSwap1;
    public bool iSwap2;
    public bool iSwap3;
    bool iSwap0;

    public int equipItemIndex = -1;

    public float maxDistance = 2.5f; //Ray의 거리 길이

    private void Start()
    {
        hasCollect_Items = new bool[99];
        hasEquip_Items = new bool[99];
    }

    public void GetInput()
    {
        iDown = Input.GetButtonDown("Interaction");
        iSwap1 = Input.GetButtonDown("Swap1");
        iSwap2 = Input.GetButtonDown("Swap2");
        iSwap3 = Input.GetButtonDown("Swap3");

        // 장착 아이템 Off
        iSwap0 = Input.GetButtonDown("Swap0");
    }

    public void Interaction()
    {
        if (iDown && nearObject != null)
        {
            // Raycast로 충돌하여 변수에 저장된 오브젝트의 태그가 "EItem" 일 때
            if (nearObject.tag == "EItem")
            {
                // Item 클래스의 item 변수는 Raycast로 충돌하여 nearObject 변수에 저장된 오브젝트의 컴포넌트 Item 클래스를 참조한다.
                Item item = nearObject.GetComponent<Item>();

                // 장착 아이템의 정수형 변수를 선언하고 값은 지역변수 item의 정의된 정수형 변수 value 이다.
                int eItemIndex = item.value;
                // 부울 변수 내에 위 변수를 저장하고 true
                hasEquip_Items[eItemIndex] = true;

                Destroy(nearObject);
            }
            // Raycast로 충돌하여 변수에 저장된 오브젝트의 태그가 "CItem"일 때
            if (nearObject.tag == "CItem")
            {
                Item item = nearObject.GetComponent<Item>();
                int cItemIndex = item.value;
                hasCollect_Items[cItemIndex] = true;
                Destroy(nearObject);
                if (SceneManager.GetActiveScene().name == "Loop2")
                {
                    brokenMirror.MirrorCount();
                    Destroy(nearObject);
                }
                //gameManager.GetComponent<GameManager>().CItemEvent();
            }
        }
    }

    //bool iSwap1Switch = false;
    // 장착 아이템 이벤트 함수
    public void ESwap()
    {
        if (iSwap1 && (!hasEquip_Items[0] || equipItemIndex == 0))
        {
            return;
        }
        if (iSwap2 && (!hasEquip_Items[1] || equipItemIndex == 1))
        {
            return;

        }
        if (iSwap3 && (!hasEquip_Items[2] || equipItemIndex == 2))
        {
            return;
        }

        // 스왑할 단축키의 값을 저장, 해당 값은 eItemIndex 정수형 변수
        int eItemIndex = -1;

        if (iSwap1) eItemIndex = 0;
        if (iSwap2) eItemIndex = 1;
        if (iSwap3) eItemIndex = 2;

        // 스왑키를 아무거나 입력할 경우
        if (iSwap1 || iSwap2 || iSwap3)
        {
            // 장착 아이템을 활성화 하고 있을 경우,(값이 없을 경우)
            if (nowEquipItem != null)
            {
                // 스왑키 입력시, 모든 오브젝트 비활성화
                nowEquipItem.SetActive(false);
            }
            equipItemIndex = eItemIndex;
            // equip_items를 초기화 전체적으로 다루기 위한 변수
            nowEquipItem = equip_Items[eItemIndex];
            // public 으로 선언된 게임오브젝트 변수 equip_Items 내에 저장된 값을 eItemIndex(스왑키 넘버)를 입력할 때 장착 오브젝트 활성화.
            nowEquipItem.SetActive(true);
            //iSwap1Switch = true;
            //장착
        }

    }

    public bool lobbyCondition3 = false;
    public void RayHit()
    {
        // Raycast Scene View 표시 형태
        Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.green);
        // Raycast 감지 형태
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerMask))
        {
            Color color = Aim.GetComponent<Image>().color;
            color.r = 1f;
            color.g = 1f;
            color.b = 0;
            color.a = 1f;
            Aim.GetComponent<Image>().color = color;

            // Raycast로 충돌한 오브젝트의 태그가 "EItem"이면?
            if (hit.transform.gameObject.CompareTag("EItem"))
            {
                Debug.Log("장착 아이템 입니다.");
                nearObject = hit.transform.gameObject;

                Debug.Log(nearObject.name + "/" + nearObject.tag);
            }
            // Raycast로 충돌한 오브젝트의 태그가 "CItem"이면?
            else if (hit.transform.gameObject.CompareTag("CItem"))
            {
                Debug.Log("수집 아이템 입니다.");
                nearObject = hit.transform.gameObject;

                Debug.Log(nearObject.name + "/" + nearObject.tag);
            }

            
            else if (hit.transform.gameObject.CompareTag("RemakeDoor"))
            {
                Debug.Log("추상 클래스로 구현한 문 입니다.");
                if (iDown)
                {
                    hit.transform.GetComponent<Door>().Open();
                    if(SceneManager.GetActiveScene().name == "Lobby")
                    {
                        lobbyCondition3 = true;
                    }
                }
            }
            else if (hit.transform.gameObject.CompareTag("RemakeChiffonier"))
            {
                Debug.Log("사물함이며, 열 수 있습니다.");
                if (iDown)
                {
                    hit.transform.GetComponent<Chiffonier>().Open();
                }
            }
            else if (hit.transform.gameObject.CompareTag("ConditionDestroy"))
            {
                if (equipItemIndex == 1)
                {
                    if (lighterSwitch.lightSwitch)
                    {
                        if (iDown)
                            StartCoroutine(DestroyFireCO());
                    }
                }

            }
            else if (hit.transform.gameObject.CompareTag("Curtain"))
            {
                if (iDown)
                    hit.transform.GetComponent<Curtain>().Open();
            }
            else if (hit.transform.gameObject.CompareTag("Closet"))
            {
                if (iDown)
                    hit.transform.GetComponent<Closet>().Open();
            }
            else if (hit.transform.gameObject.CompareTag("Bell"))
            {
                if (iDown)
                    hit.transform.GetComponent<Bell>().BellSound();
            }
            else if (hit.transform.gameObject.CompareTag("BigRabbitDoll"))
            {
                if (iDown)
                    hit.transform.GetComponent<BigRabbitDoll>().DollSound();
            }
        }
        else
        {
            nearObject = null;

            Color color = Aim.GetComponent<Image>().color;
            color.r = 1f;
            color.g = 1f;
            color.b = 1f;
            color.a = 0.3f;
            Aim.GetComponent<Image>().color = color;

            Debug.Log("상호작용 할 수 있는 오브젝트가 아닙니다.");
        }
    }

    public bool EventOn = false;
    IEnumerator DestroyFireCO()
    {
        yield return new WaitForSeconds(0.0f);
        fireShader.SetActive(true);
        yield return new WaitForSeconds(3f);
        fireShader.SetActive(false);
        surpriseEvent.bigBear.SetActive(false);
        EventOn = true;
    }

    void Update()
    {
        Interaction();
        GetInput();
        ESwap();
        RayHit();
    }
}
