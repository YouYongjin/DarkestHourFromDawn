using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotateMove : MonoBehaviour
{
    //public Transform cameraT;
    //public Transform targetT;

    //public float speed = 10f;

    private void Start()
    {   
        //speed = speed * Time.deltaTime;
    }
    public void TargetRotateEvent(Transform camera, Transform target, float speed)
    {
        speed = 10f;
        speed = speed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(camera.rotation, target.rotation, speed);
    }
}
