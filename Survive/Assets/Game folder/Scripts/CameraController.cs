using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Getting the transforms of the body and gun to move with camera
    public Transform gunRot;
    public Transform playerBody;
    //Other variables
    public float mouseSen = 1.0f;
    private float xRot = 0.0f;


    //Lock cursor to middle of screen
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Rotate relevant parts with mouse movement
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSen * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSen * Time.deltaTime;

        xRot -= mouseY;

        //Rotate camera on x axis (spinning up and down and vice versa)
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        //Rotate gun on x axis 
        gunRot.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        //Rotate body on y axis which in turn rotates camera as its a child (spinning left to right and vice versa)
        playerBody.Rotate(Vector3.up * mouseX);


    }
}
