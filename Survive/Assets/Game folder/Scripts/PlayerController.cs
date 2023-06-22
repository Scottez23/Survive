using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    //action keys
    public KeyCode forwardsKey = KeyCode.W;
    public KeyCode backwardsKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode sprintKey = KeyCode.LeftShift;
    


    //Movement variables
    public float forwardSpeed = 0.1f;
    public float backwardSpeed = 0.08f;
    public float strafeSpeed = 0.08f;
    public float sprintMod = 1.5f;

     
       
    //So player current position can be called
    public Vector3 CurrentPos()
    {
        return transform.position;
    }

    //movement
    void Update()
    {
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100.0f, Color.red);


        //if forwards key is pressed, move forward. Sprint if shift is down too
        if (Input.GetKey(forwardsKey))
        {
            if (Input.GetKey(sprintKey))
            {
                transform.position = transform.position + (transform.forward * (forwardSpeed * sprintMod / 4));
            }
            else
            {
                transform.position = transform.position + (transform.forward * (forwardSpeed / 4));
            }
        }

        //if backwards key is pressed, move backward. Sprint if shift is down too
        if (Input.GetKey(backwardsKey))
        {
            if (Input.GetKey(sprintKey))
            {
                transform.position = transform.position + (transform.forward * -(backwardSpeed * sprintMod / 4));
            }
            else
            {
                transform.position = transform.position + (transform.forward * -(backwardSpeed / 4));
            }
        }

        //if left key is pressed, move to the left
        if (Input.GetKey(leftKey))
        {
            
                transform.position = transform.position + (transform.right * -(strafeSpeed / 4));
            
        }

        //if right key is pressed, move to the right
        if (Input.GetKey(rightKey))
        {
            
                transform.position = transform.position + (transform.right * (strafeSpeed / 4));
            
        }


    }
}
