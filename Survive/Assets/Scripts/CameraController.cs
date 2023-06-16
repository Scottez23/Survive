using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform gunRot;
    public Transform playerBody;

    public float mouseSen = 1.0f;

    private float xRot = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSen * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSen * Time.deltaTime;

        xRot -= mouseY;

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        gunRot.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);


    }
}
