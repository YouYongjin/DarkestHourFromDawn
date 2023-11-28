using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
        speed = speed * Time.deltaTime;
        // transform.rotation = Quaternion.RotateTowards(camera.rotation, target.rotation, speed);

        Vector3 pos = camera.position + camera.forward;

        Vector3 lerpPos = Vector3.Lerp(pos, target.position, speed);
        transform.LookAt(lerpPos);

        Debug.Log("Rotate ½ÇÇà");
    }
}
