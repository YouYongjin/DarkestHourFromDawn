using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    public OpenDoorV2 DoorOn;
    public NoneDoorV2 DoorOff;
    RaycastHit hit;
    public LayerMask layerMask;

    public GameObject Aim;
    GameObject nearObject;
    GameObject nowEquipItem;

    // ǥ���� ������ ����
    public GameObject[] equip_Items;
    public GameObject[] collect_Items;

    // ������ ȹ�� ����
    public bool[] hasEquip_Items;
    public bool[] hasCollect_Items;

    bool iDown;
    bool iSwap1;
    bool iSwap2;
    bool iSwap3;
    bool iSwap0;

    int equipItemIndex = -1;

    public float maxDistance = 2f; //Ray�� �Ÿ� ����

    void GetInput()
    {
        iDown = Input.GetButtonDown("Interaction");
        iSwap1 = Input.GetButtonDown("Swap1");
        iSwap2 = Input.GetButtonDown("Swap2");
        iSwap3 = Input.GetButtonDown("Swap3");

        // ���� ������ Off
        iSwap0 = Input.GetButtonDown("Swap0");
    }

    void Interaction()
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
            }
        }
    }

    // ���� ������ �̺�Ʈ �Լ�
    void ESwap()
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
        }

        // ���� ������ �̺�Ʈ �Լ�
        //void CSwap()
        //{

        //}


    }

    public void RayHit()
    {
        // Raycast Scene View ǥ�� ����
        Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.green);
        // Raycast ���� ����
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerMask))
        {
            Color color = Aim.GetComponent<Image>().color;
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

            // Raycast�� �浹�� ������Ʈ�� �±װ� "Door"�̸�?
            else if (hit.transform.gameObject.CompareTag("Door"))
            {
                Debug.Log("��(��) �̸�, �� �� �ֽ��ϴ�.");
                if (iDown)
                {
                    hit.transform.GetComponent<OpenDoorV2>().DoorOnEvent();
                    //DoorOn.DoorOnEvent();
                    Debug.Log("�� ��ȣ�ۿ�");
                }
            }

            // Raycast�� �浹�� ������Ʈ�� �±װ� "Door(None)"�̸�?
            else if (hit.transform.gameObject.CompareTag("Door(None)"))
            {
                Debug.Log("��(��) �̸�, �� �� �����ϴ�.");
                if (iDown)
                {
                    hit.transform.GetComponent<NoneDoorV2>().DoorOffEvent();
                }
            }

            else if(hit.transform.gameObject.CompareTag("Chiffonier"))
            {
                Debug.Log("�繰���̸�, �� �� �ֽ��ϴ�.");
                if (iDown)
                {
                    hit.transform.GetComponent<OpenChiffonierV2>().StorageOnEvent();
                }
            }
        }
        else
        {
            nearObject = null;

            Color color = Aim.GetComponent<Image>().color;
            color.a = 0.3f;
            Aim.GetComponent<Image>().color = color;

            Debug.Log("��ȣ�ۿ� �� �� �ִ� ������Ʈ�� �ƴմϴ�.");
        }
    }

    void Update()
    {
        Interaction();
        GetInput();
        ESwap();
        RayHit();
        //CSwap();
    }

}
