using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public SurpriseEvent supEvt;

    // Variables
    public Transform player;
    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0f;

    bool lockedCursor = true;
    public bool CameraMoveOn = true;

    public void CameraMove()
    {
        // 서프라이즈 이벤트 발동 시간 동안은 작동 안하도록 제어 추가
        if (CameraMoveOn && !supEvt.lookAtBear)
        {
            // Collect Mouse Input

            float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            // Rotate the Camera around its local X axis

            cameraVerticalRotation -= inputY;
            cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -80f, 80f);
            transform.localEulerAngles = Vector3.right * cameraVerticalRotation;


            // Rotate the Player Object and the Camera around its Y axis

            player.Rotate(Vector3.up * inputX);
        }
    }

    void Start()
    {
        // Lock and Hide the Cursor
        Cursor.visible = false;
        CursorLock();
    }

    void CursorLock()
    {
        if (CameraMoveOn)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (!CameraMoveOn)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }


    void Update()
    {
        CameraMove();
        CursorLock();
    }
}
