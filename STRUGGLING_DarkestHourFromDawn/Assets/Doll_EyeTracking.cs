using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll_EyeTracking : MonoBehaviour
{
    public Transform target;
    public GameObject eye1;
    public GameObject eye2;

    public void LookAtTarget()
    {
        eye1.transform.LookAt(target.position);
        eye2.transform.LookAt(target.position);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            LookAtTarget();
        }
    }
}
