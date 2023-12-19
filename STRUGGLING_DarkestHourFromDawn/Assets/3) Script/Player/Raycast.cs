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

    // ǥ���� ������ ����
    public GameObject[] equip_Items;
    public GameObject[] collect_Items;

    // ������ ȹ�� ����
    public bool[] hasEquip_Items;
    public bool[] hasCollect_Items;

    public bool iDown;
    public bool iSwap1;
    public bool iSwap2;
    public bool iSwap3;
    bool iSwap0;

    public int equipItemIndex = -1;

    public float maxDistance = 2.5f; //Ray�� �Ÿ� ����

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

        // ���� ������ Off
        iSwap0 = Input.GetButtonDown("Swap0");
    }

    public void Interaction()
    {
        if (iDown && nearObject != null)
        {
            // Raycast�� �浹�Ͽ� ������ ����� ������Ʈ�� �±װ� "EItem" �� ��
            if (nearObject.tag == "EItem")
            {
                // Item Ŭ������ item ������ Raycast�� �浹�Ͽ� nearObject ������ ����� ������Ʈ�� ������Ʈ Item Ŭ������ �����Ѵ�.
                Item item = nearObject.GetComponent<Item>();

                // ���� �������� ������ ������ �����ϰ� ���� �������� item�� ���ǵ� ������ ���� value �̴�.
                int eItemIndex = item.value;
                // �ο� ���� ���� �� ������ �����ϰ� true
                hasEquip_Items[eItemIndex] = true;

                Destroy(nearObject);
            }
            // Raycast�� �浹�Ͽ� ������ ����� ������Ʈ�� �±װ� "CItem"�� ��
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
    // ���� ������ �̺�Ʈ �Լ�
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

        // ������ ����Ű�� ���� ����, �ش� ���� eItemIndex ������ ����
        int eItemIndex = -1;

        if (iSwap1) eItemIndex = 0;
        if (iSwap2) eItemIndex = 1;
        if (iSwap3) eItemIndex = 2;

        // ����Ű�� �ƹ��ų� �Է��� ���
        if (iSwap1 || iSwap2 || iSwap3)
        {
            // ���� �������� Ȱ��ȭ �ϰ� ���� ���,(���� ���� ���)
            if (nowEquipItem != null)
            {
                // ����Ű �Է½�, ��� ������Ʈ ��Ȱ��ȭ
                nowEquipItem.SetActive(false);
            }
            equipItemIndex = eItemIndex;
            // equip_items�� �ʱ�ȭ ��ü������ �ٷ�� ���� ����
            nowEquipItem = equip_Items[eItemIndex];
            // public ���� ����� ���ӿ�����Ʈ ���� equip_Items ���� ����� ���� eItemIndex(����Ű �ѹ�)�� �Է��� �� ���� ������Ʈ Ȱ��ȭ.
            nowEquipItem.SetActive(true);
            //iSwap1Switch = true;
            //����
        }

    }

    public bool lobbyCondition3 = false;
    public void RayHit()
    {
        // Raycast Scene View ǥ�� ����
        Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.green);
        // Raycast ���� ����
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerMask))
        {
            Color color = Aim.GetComponent<Image>().color;
            color.r = 1f;
            color.g = 1f;
            color.b = 0;
            color.a = 1f;
            Aim.GetComponent<Image>().color = color;

            // Raycast�� �浹�� ������Ʈ�� �±װ� "EItem"�̸�?
            if (hit.transform.gameObject.CompareTag("EItem"))
            {
                Debug.Log("���� ������ �Դϴ�.");
                nearObject = hit.transform.gameObject;

                Debug.Log(nearObject.name + "/" + nearObject.tag);
            }
            // Raycast�� �浹�� ������Ʈ�� �±װ� "CItem"�̸�?
            else if (hit.transform.gameObject.CompareTag("CItem"))
            {
                Debug.Log("���� ������ �Դϴ�.");
                nearObject = hit.transform.gameObject;

                Debug.Log(nearObject.name + "/" + nearObject.tag);
            }

            
            else if (hit.transform.gameObject.CompareTag("RemakeDoor"))
            {
                Debug.Log("�߻� Ŭ������ ������ �� �Դϴ�.");
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
                Debug.Log("�繰���̸�, �� �� �ֽ��ϴ�.");
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

            Debug.Log("��ȣ�ۿ� �� �� �ִ� ������Ʈ�� �ƴմϴ�.");
        }
    }
    IEnumerator DestroyFireCO()
    {
        yield return new WaitForSeconds(0.0f);
        fireShader.SetActive(true);
        yield return new WaitForSeconds(3f);
        fireShader.SetActive(false);
        surpriseEvent.bigBear.SetActive(false);
    }

    void Update()
    {
        Interaction();
        GetInput();
        ESwap();
        RayHit();
    }
}
