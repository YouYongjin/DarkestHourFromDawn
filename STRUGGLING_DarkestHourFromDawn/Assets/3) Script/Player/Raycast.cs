using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    RaycastHit hit;
    public float maxDistance = 2f; //Ray�� �Ÿ� ����
    //public Camera camera;
    public LayerMask layerMask;
    GameObject nearObject;


    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * maxDistance, Color.green);
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerMask))
        {
            if (hit.transform.gameObject.CompareTag("EItem"))
            {
                Debug.Log("���� ������ �Դϴ�.");
                nearObject = hit.transform.gameObject;
                Debug.Log(nearObject.name + "/" + nearObject.tag);
                if (Input.GetKey(KeyCode.E))
                {
                    Debug.Log("����");
                    Destroy(hit.transform.gameObject);
                }
            }
        }
        else
        {
            nearObject = null;
            Debug.Log("���� �����ۿ��� ������ϴ�.");
        }
    }
}
