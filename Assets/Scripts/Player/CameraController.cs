using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float sensitivityH = 2f;
    public float sensitivityV = 2f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rotateCamera();
    }

    private void rotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountH = mouseX * sensitivityH;
        float rotAmountV = mouseY * sensitivityV;

        Vector3 targetRot = transform.rotation.eulerAngles;
        targetRot.x += -rotAmountV;
        targetRot.y += rotAmountH;

        transform.rotation = Quaternion.Euler(targetRot);

    }
}
