using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public float sensitivityH = 2f;
    public float sensitivityV = 2f;
    public Camera playerCamera;

    private float xRotClamp = 0.0f;

    // Use this for initialization
    void Start()
    {
        // Lock Cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        rotateCamera();
    }

    private void OnDestroy()
    {
        // Unlock Cursor
        Cursor.lockState = CursorLockMode.None;
    }

    private void rotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountH = mouseX * sensitivityH;
        float rotAmountV = mouseY * sensitivityV;

        xRotClamp -= rotAmountV;

        Vector3 cameraRot = playerCamera.transform.rotation.eulerAngles;
        Vector3 bodyRot = transform.rotation.eulerAngles;

        cameraRot.x -= rotAmountV;
        cameraRot.z = 0f;               // Avoid camera going upside down        

        bodyRot.y += rotAmountH;

        // Check Camera Limits
        if (xRotClamp > 90)
        {
            xRotClamp = 90;
            cameraRot.x = 90;
        }
        else if (xRotClamp < -90)
        {
            xRotClamp = -90;
            cameraRot.x = 270;
        }

        playerCamera.transform.rotation = Quaternion.Euler(cameraRot);
        transform.rotation = Quaternion.Euler(bodyRot);
    }
}
