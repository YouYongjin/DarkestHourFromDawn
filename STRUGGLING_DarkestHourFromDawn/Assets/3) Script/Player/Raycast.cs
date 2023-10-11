using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    public OpenDoorV2 DoorScript;
    RaycastHit hit;
    public LayerMask layerMask;
    public Animator anim;
    //public AudioSource audioSource_Door;
    //public AudioSource audioSource;

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
    public bool isDoorOn = false;

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
                Debug.Log("��(����) �Դϴ�.");
                if (iDown)
                {
                    //if (!isDoorOn)
                    //{
                    //    anim.SetBool("isDoorOn", true);
                    //    isDoorOn = true;
                    //    //SoundManager.instance.PlayAudioSource(audioSource_Door, SoundManager.instance.dataBase.soundEffect[4]);
                    //}
                    //else if (isDoorOn)
                    //{
                    //    anim.SetBool("isDoorOn", false);
                    //    isDoorOn = false;
                    //}
                    DoorScript.DoorEvent();
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