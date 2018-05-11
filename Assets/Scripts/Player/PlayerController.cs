using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float sensitivityH = 2f;
    public float sensitivityV = 2f;

    public Camera playerCamera;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Lock Cursor
        Cursor.lockState = CursorLockMode.Locked;

        rotateCamera();
    }

    private void rotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountH = mouseX * sensitivityH;
        float rotAmountV = mouseY * sensitivityV;

        Vector3 cameraRot = playerCamera.transform.rotation.eulerAngles;
        Vector3 bodyRot = transform.rotation.eulerAngles;
        cameraRot.x -= rotAmountV;
        bodyRot.y += rotAmountH;

        playerCamera.transform.rotation = Quaternion.Euler(cameraRot);
        transform.rotation = Quaternion.Euler(bodyRot);
    }
}
