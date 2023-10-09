using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    RaycastHit hit;
    public float maxDistance = 2f; //Ray의 거리 길이
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
                Debug.Log("장착 아이템 입니다.");
                nearObject = hit.transform.gameObject;
                Debug.Log(nearObject.name + "/" + nearObject.tag);
                if (Input.GetKey(KeyCode.E))
                {
                    Debug.Log("삭제");
                    Destroy(hit.transform.gameObject);
                }
            }
        }
        else
        {
            nearObject = null;
            Debug.Log("장착 아이템에서 벗어났습니다.");
        }
    }
}
