using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target;
    Camera mainCam;
    public Vector3 offset;
    public float damping;
 

    private Vector3 velocity = Vector3.zero; //Make variable velocity and initalizes it to 0

    void FixedUpdate()
    {

        Vector3 movePosition = target.position + offset; // Calculates the positon 
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping); //Smooths the camera.  
    }



}
